const _uri = "/api/toppings";

export const getAllToppings = () => {
  return fetch(_uri).then((res) => res.json());
};
