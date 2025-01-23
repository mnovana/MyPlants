import { useDispatch } from "react-redux";
import { logout } from "../store/slices/userSlice";
import { useNavigate } from "react-router-dom";

function FooterMobile() {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  function handleLogout() {
    dispatch(logout());
    navigate("/login");
  }

  return (
    <div className="flex-1 flex flex-col-reverse">
      <div className="h-36 bg-green-800 text-white underline flex justify-center items-center lg:hidden">
        <button onClick={handleLogout}>logout</button>
      </div>
    </div>
  );
}

export default FooterMobile;
