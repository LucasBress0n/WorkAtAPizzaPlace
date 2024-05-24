const _uri = "/api/pizza";

export const createNewPizza = (pizzaObject) => {
  return fetch(_uri, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(pizzaObject),
  }).then((res) => res.json());
};
