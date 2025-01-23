import { NavLink } from "react-router-dom";

function MenuMobile() {
  return (
    <>
      <NavLink to="/" className={({ isActive }) => `p-2 w-32 border rounded-full text-center hover:shadow-lg ${isActive && "font-black border-black"}`}>
        SCHEDULE
      </NavLink>

      <NavLink to="/plants" className={({ isActive }) => `p-2 w-32 border rounded-full text-center hover:shadow-lg ${isActive && "font-black border-black"}`}>
        PLANTS
      </NavLink>
    </>
  );
}

export default MenuMobile;
