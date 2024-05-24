const _uri = "/api/size";

export const getAllSizes = () => {
  return fetch(_uri).then((res) => res.json());
};
