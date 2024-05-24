import { useEffect, useState } from "react";
import { getAllOrders } from "../../../managers/order";
import "./HomeView.css";
import { Link } from "react-router-dom";

export const HomeView = () => {
  const [allOrders, setAllOrders] = useState([]);

  useEffect(() => {
    getAllOrders().then(setAllOrders);
  }, []);

  return (
    <main>
      <div className="HomeView-mainpizza-containers">
        {allOrders.map((o) => {
          return (
            <article key={o.id} className="HomeView-pizza-info">
              <div className="HomeView-employee-info">
                <Link to={`${o.id}`}>Order</Link>
                <p>
                  Phone: {o.userProfile.fullName}{" "}
                  {o.delivererProfile?.fullName != null &&
                    `Driver: ${o.delivererProfile.fullName}`}
                </p>
                <p>Date: {o.completedOnDate}</p>
              </div>
              <section>
                {o.pizzas.map((p) => {
                  return (
                    <article key={p.id}>
                      <div className="HomeView-pizza-details">
                        <p>Size: {p.size.name}</p>
                        <p>PizzaSize: {p.size.pizzaSize}</p>
                        <p>Price: {p.size.price}$</p>
                        <p>Cheese: {p.cheese.name}</p>
                        <p>Sauce: {p.sauce.name}</p>
                      </div>
                      <section>
                        {p.pizzaToppings.map((pt) => {
                          return (
                            <article key={pt.pizzaId + pt.toppingId}>
                              Topping: {pt.topping.name} Price:{" "}
                              {pt.topping.price}$
                            </article>
                          );
                        })}
                      </section>
                    </article>
                  );
                })}
              </section>
            </article>
          );
        })}
      </div>
    </main>
  );
};
