import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { HomeView } from "./views/HomeViewFolder/HomeView";
import { CreateOrderView } from "./views/CreateOrderViewFolder/CreateOrderView";
import { OrderDetailsView } from "./views/OrderDetailsViewFolder/OrderDetailsView";

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <HomeView />
            </AuthorizedRoute>
          }
        />
        <Route path=":OrderId" element={<OrderDetailsView />} />
        <Route
          path="createorder"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <CreateOrderView loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}
