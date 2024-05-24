import { useEffect, useState } from "react";
import { getAllToppings } from "../../../managers/toppings";
import { getAllUserProfiles } from "../../../managers/userprofile";
import "./CreateOrderView.css";
import { getAllSizes } from "../../../managers/size";
import { createToppingsView } from "./CreateOrderModules";
import { getAllCheeses } from "../../../managers/cheese";
import { getAllSauces } from "../../../managers/sauce";
import { createNewOrder } from "../../../managers/order";
import { createNewPizza } from "../../../managers/pizza";
import { addPizzaTopping } from "../../../managers/pizzaTopping";
import { useNavigate } from "react-router-dom";

export const CreateOrderView = ({ loggedInUser }) => {
  // Data
  const [currentOrder, setCurrentOrder] = useState({
    UserProfileId: loggedInUser.id,
  });
  const [allToppings, setAllToppings] = useState([]);
  const [allSizes, setAllSizes] = useState([]);
  const [allCheeses, setAllCheeses] = useState([]);
  const [allSauces, setAllSauces] = useState([]);
  const [allEmployees, setAllEmployees] = useState([]);

  // Function Data
  const navigate = useNavigate();
  const [allPizzas, setAllPizzas] = useState([]);
  const [allPizzaToppings, setAllPizzaToppings] = useState([]);
  const [selectedPizza, setSelectedPizza] = useState(0);

  useEffect(() => {
    getAllSauces().then(setAllSauces);
  }, []);

  useEffect(() => {
    getAllCheeses().then(setAllCheeses);
  }, []);

  useEffect(() => {
    getAllSizes().then(setAllSizes);
  }, []);

  useEffect(() => {
    getAllToppings().then(setAllToppings);
  }, []);

  useEffect(() => {
    getAllUserProfiles().then(setAllEmployees);
  }, []);

  const handleAddDriverToOrder = (e) => {
    const copy = { ...currentOrder };
    copy.DelivererId = parseInt(e.target.value);
    setCurrentOrder(copy);
  };

  const handleAddPizza = () => {
    const copy = [...allPizzas];
    if (allPizzas.length == 0) {
      copy.push({
        Id: 1,
        OrderId: 0,
        SizeId: 1,
        CheeseId: 4,
        SauceId: 4,
      });
    } else {
      copy.push({
        Id: allPizzas[allPizzas.length - 1].Id + 1,
        OrderId: 0,
        SizeId: 1,
        CheeseId: 4,
        SauceId: 4,
      });
    }
    setAllPizzas(copy);
  };

  const handlePizzaDelete = (p) => {
    let copy = [...allPizzas];
    copy = copy.filter((pi) => pi.Id != p.Id);
    setAllPizzas(copy);

    let toppingsCopy = [...allPizzaToppings];
    toppingsCopy = toppingsCopy.filter((t) => t.PizzaId != p.Id);
    setAllPizzaToppings(toppingsCopy);
    setSelectedPizza(0);
  };

  const handleAddPizzaTopping = (toppingId, pizzaId) => {
    const foundTopping = allPizzaToppings.filter(
      (pt) => pt.ToppingId == toppingId && pt.PizzaId == pizzaId
    );

    if (foundTopping.length == 0) {
      const copy = [...allPizzaToppings];
      copy.push({ ToppingId: toppingId, PizzaId: pizzaId });
      setAllPizzaToppings(copy);
    }
  };

  const handleDeletePizzaTopping = (toppingId, pizzaId) => {
    let copy = [...allPizzaToppings];
    copy = copy.filter(
      (pt) => !(pt.ToppingId === toppingId && pt.PizzaId === pizzaId)
    );
    setAllPizzaToppings(copy);
  };

  const handleSizeChange = (pickedPizza, s) => {
    const copy = [...allPizzas];
    copy.forEach((pizza) => {
      if (pizza.Id == pickedPizza.Id) {
        pizza.SizeId = s.id;
      }
      setAllPizzas(copy);
    });
  };

  const handleSauceChange = (pickedPizza, s) => {
    const copy = [...allPizzas];
    copy.forEach((pizza) => {
      if (pizza.Id == pickedPizza.Id) {
        pizza.SauceId = s.id;
      }
      setAllPizzas(copy);
    });
  };

  const handleCheeseChange = (pickedPizza, c) => {
    const copy = [...allPizzas];
    copy.forEach((pizza) => {
      if (pizza.Id == pickedPizza.Id) {
        pizza.CheeseId = c.id;
      }
      setAllPizzas(copy);
    });
  };

  const handleSubmit = () => {
    createNewOrder(currentOrder).then((orderObject) => {
      allPizzas.forEach((pizzaObject) => {
        const PizzaObjectId = pizzaObject.Id;
        pizzaObject.OrderId = orderObject.id;
        delete pizzaObject.Id;
        createNewPizza(pizzaObject).then((createdPizzaObject) => {
          allPizzaToppings.forEach((pizTopObj) => {
            if (pizTopObj.PizzaId == PizzaObjectId) {
              pizTopObj.PizzaId = createdPizzaObject.id;
              addPizzaTopping(pizTopObj);
              pizTopObj.PizzaId = 0;
            }
          });
        });
      });
    });
    navigate("/");
  };

  return (
    <main>
      <div className="CreateOrderView-main-div">
        <button
          onClick={() => {
            handleSubmit();
          }}
        >
          Submit
        </button>
        <section className="CreateOrderView-select-dropdowns">
          <select onChange={handleAddDriverToOrder}>
            <option hidden value={0}>
              Pick Driver
            </option>
            {allEmployees.map((e) => {
              return (
                <option key={e.id} value={e.id}>
                  {e.fullName}
                </option>
              );
            })}
          </select>
        </section>
        <button onClick={handleAddPizza}>Add</button>
        <div className="CreateOrderView-pizzabox-main-container">
          <section className="CreateOrderView-pizza-main-container">
            {allPizzas.map((p) => {
              return (
                <article key={p.Id}>
                  <p
                    onClick={() => {
                      setSelectedPizza(p.Id);
                    }}
                  >
                    Pizza {p.Id}
                  </p>
                  <button
                    onClick={() => {
                      handlePizzaDelete(p);
                    }}
                  >
                    Delete
                  </button>
                </article>
              );
            })}
          </section>
          <section className="CreateOrderView-main-modifiers-container">
            <section>
              {selectedPizza != 0 &&
                allToppings.map((t) => {
                  return createToppingsView(
                    allPizzaToppings,
                    t,
                    handleDeletePizzaTopping,
                    handleAddPizzaTopping,
                    selectedPizza
                  );
                })}
            </section>
            <section>
              {selectedPizza != 0 &&
                allSizes.map((s) => {
                  const pickedPizza = allPizzas.find(
                    (p) => p.Id == selectedPizza
                  );
                  return (
                    <article key={s.id}>
                      <label>
                        {s.name} {s.pizzaSize}" {s.price}$
                      </label>
                      <input
                        name="PizzaSize"
                        type="radio"
                        onChange={() => {
                          handleSizeChange(pickedPizza, s);
                        }}
                        checked={pickedPizza.SizeId == s.id}
                      />
                    </article>
                  );
                })}
            </section>
            <section>
              {selectedPizza != 0 &&
                allSauces.map((s) => {
                  const pickedPizza = allPizzas.find(
                    (p) => p.Id == selectedPizza
                  );
                  return (
                    <article key={s.id}>
                      <label>{s.name}</label>
                      <input
                        name="PizzaSauce"
                        type="radio"
                        onChange={() => {
                          handleSauceChange(pickedPizza, s);
                        }}
                        checked={pickedPizza.SauceId == s.id}
                      />
                    </article>
                  );
                })}
            </section>
            <section>
              {selectedPizza != 0 &&
                allCheeses.map((c) => {
                  const pickedPizza = allPizzas.find(
                    (p) => p.Id == selectedPizza
                  );
                  return (
                    <article key={c.id}>
                      <label>{c.name}</label>
                      <input
                        name="PizzaCheese"
                        type="radio"
                        onChange={() => {
                          handleCheeseChange(pickedPizza, c);
                        }}
                        checked={pickedPizza.CheeseId == c.id}
                      />
                    </article>
                  );
                })}
            </section>
          </section>
        </div>
      </div>
    </main>
  );
};

{
  /* <section>
{selectedPizza != 0 &&
  allCheeses.map((c) => {
    const foundPizza = allPizzas.find(
      (p) => p.Id == selectedPizza
    );
    if (foundPizza.CheeseId == c.id) {
      return (
        <article key={c.id}>
          <label>{c.name}</label>
          <input type="checkbox" defaultChecked />
        </article>
      );
    } else {
      return (
        <article key={c.id}>
          <label>{c.name}</label>
          <input type="checkbox" />
        </article>
      );
    }
  })}
</section>
<section>
{selectedPizza != 0 &&
  allSauces.map((s) => {
    const foundPizza = allPizzas.find(
      (p) => p.Id == selectedPizza
    );
    if (foundPizza.SauceId == s.id) {
      return (
        <article key={s.id}>
          <label>{s.name}</label>
          <input type="checkbox" defaultChecked />
        </article>
      );
    } else {
      return (
        <article key={s.id}>
          <label>{s.name}</label>
          <input type="checkbox" />
        </article>
      );
    }
  })}
</section> */
}
