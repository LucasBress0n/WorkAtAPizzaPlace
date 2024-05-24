const _uri = "/api/pizzatopping";

export const addPizzaTopping = (newPizzaTopping) => {
  return fetch(_uri, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(newPizzaTopping),
  });
};
