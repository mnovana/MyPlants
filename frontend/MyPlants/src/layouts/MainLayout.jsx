import { useSelector } from "react-redux";
import FooterMobile from "./FooterMobile";
import Header from "./Header";
import { Outlet } from "react-router-dom";

function MainLayout() {
  const isLoggedIn = useSelector((state) => state.user.isLoggedIn);

  return (
    <div className="min-h-screen flex flex-col">
      <Header />
      <Outlet />
      {isLoggedIn && <FooterMobile />}
    </div>
  );
}

export default MainLayout;
