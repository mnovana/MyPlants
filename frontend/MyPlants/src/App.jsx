import { createBrowserRouter, createRoutesFromElements, Route, RouterProvider } from "react-router-dom";
import MainLayout from "./layouts/MainLayout";
import HomePage from "./pages/HomePage";
import PlantsPage from "./pages/PlantsPage";
import LoginPage from "./pages/LoginPage";

function App() {
  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route element={<MainLayout />}>
        <Route index element={<HomePage />} />
        <Route path="/plants" element={<PlantsPage />} />
        <Route path="/login" element={<LoginPage />} />
      </Route>
    )
  );

  return <RouterProvider router={router} />;
}

export default App;
