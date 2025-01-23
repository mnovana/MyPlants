import { NavLink } from "react-router-dom";

function MenuDesktop() {
  return (
    <>
      <NavLink to="/" className={({ isActive }) => (isActive ? "underline" : "hover:underline")}>
        SCHEDULE
      </NavLink>

      <NavLink to="/plants" className={({ isActive }) => (isActive ? "underline" : "hover:underline")}>
        PLANTS
      </NavLink>

      <button className="hover:underline">LOGOUT</button>
    </>
  );
}

export default MenuDesktop;
