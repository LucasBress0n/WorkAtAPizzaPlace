const _uri = "/api/sauce";

export const getAllSauces = () => {
  return fetch(_uri).then((res) => res.json());
};
