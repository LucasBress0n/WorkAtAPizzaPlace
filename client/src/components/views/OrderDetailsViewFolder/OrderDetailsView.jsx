import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getOrderById } from "../../../managers/order";

export const OrderDetailsView = () => {
  const [order, setOrder] = useState({});
  const { OrderId } = useParams();

  useEffect(() => {
    getOrderById(OrderId).then(setOrder);
  }, []);

  return (
    <main>
      <article key={order.id} className="HomeView-pizza-info">
        <div className="HomeView-employee-info">
          <p>
            Phone: {order.userProfile?.fullName}{" "}
            {order.delivererProfile?.fullName != null &&
              `Driver: ${order.delivererProfile.fullName}`}
          </p>
          <p>Date: {order.completedOnDate}</p>
        </div>
        <section>
          {order?.pizzas?.map((p) => {
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
                        Topping: {pt.topping.name} Price: {pt.topping.price}$
                      </article>
                    );
                  })}
                </section>
              </article>
            );
          })}
        </section>
      </article>
    </main>
  );
};
