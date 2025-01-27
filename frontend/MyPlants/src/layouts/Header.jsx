import { useSelector } from "react-redux";
import gardenerImg from "../assets/gardener.png";
import MenuDesktop from "./MenuDesktop";
import MenuMobile from "./MenuMobile";

function Header() {
  const user = useSelector((state) => state.user);

  return (
    <>
      <div className="flex justify-between items-center mx-10 mt-10">
        <div>
          <div className="text-6xl font-bold text-green-800">My Plants</div>
          <div className="text-xl tracking-wide">Track plants and their watering schedule!</div>
        </div>

        {user.isLoggedIn && (
          <div className="flex-1 hidden lg:flex justify-evenly">
            <MenuDesktop />
          </div>
        )}

        <img src={gardenerImg} className="h-28" />
      </div>

      {user.isLoggedIn && <div className="text-3xl mx-10 lg:mx-20">{`Hi, ${user.email} 🍀`}</div>}

      {user.isLoggedIn && (
        <div className="lg:hidden flex justify-evenly">
          <MenuMobile />
        </div>
      )}
    </>
  );
}

export default Header;
