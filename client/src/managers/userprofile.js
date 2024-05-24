const _uri = "/api/userprofile";

export const getAllUserProfiles = () => {
  return fetch(_uri).then((res) => res.json());
};
