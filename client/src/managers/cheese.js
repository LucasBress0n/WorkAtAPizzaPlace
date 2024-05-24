const _uri = "/api/cheese";

export const getAllCheeses = () => {
  return fetch(_uri).then((res) => res.json());
};
