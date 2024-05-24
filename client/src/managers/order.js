const _uri = "/api/order";

export const getAllOrders = () => {
  return fetch(_uri).then((res) => res.json());
};

export const createNewOrder = (newOrder) => {
  return fetch(_uri, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(newOrder),
  }).then((res) => res.json());
};

export const getOrderById = (Id) => {
  return fetch(`${_uri}/${Id}`).then((res) => res.json());
};
