import { useState } from "react";
import { useDispatch } from "react-redux";
import { login } from "../store/slices/userSlice";
import { useNavigate } from "react-router-dom";

function LoginForm() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [validationMessage, setValidationMessage] = useState("");

  const dispatch = useDispatch();
  const navigate = useNavigate();

  function submitForm(e) {
    e.preventDefault();

    if (formIsValid()) {
      const user = { email, password };
      console.log(user);

      fetch("https://localhost:7252/api/login", { method: "POST", headers: { "Content-Type": "application/json" }, body: JSON.stringify(user) })
        .then((response) => {
          if (response.status == 200) {
            response.json().then((data) => {
              localStorage.setItem("token", data.token);
              dispatch(login({ email: data.email }));
              navigate("/");
            });
          } else {
            console.log("Failed login status code: " + response.status);
            setValidationMessage("Failed login");
          }
        })
        .catch((error) => alert(error));
    }
  }

  function formIsValid() {
    if (!email || !password) {
      setValidationMessage("Empty field");
      return false;
    }
    if (password.length < 6) {
      setValidationMessage("Password shorter than 6 characters");
      return false;
    }

    return true;
  }

  return (
    <div className="flex flex-col bg-green-100 bg-opacity-40 md:w-1/2 w-5/6 h-fit shadow-md gap-20 md:gap-10 m-10">
      <h1 className="text-3xl text-center m-5">Login</h1>

      <form className="flex-1 flex flex-col justify-evenly items-center gap-20 md:gap-10" onSubmit={submitForm}>
        <input
          type="text"
          placeholder="Email"
          className="p-4 md:p-2 rounded-xl md:w-2/3 w-5/6 shadow-inner border"
          onChange={(e) => {
            setValidationMessage("");
            setEmail(e.target.value);
          }}
        />
        <input
          type="password"
          placeholder="Password"
          className="p-4 md:p-2 rounded-xl md:w-2/3 w-5/6 shadow-inner border"
          onChange={(e) => {
            setValidationMessage("");
            setPassword(e.target.value);
          }}
        />

        <div className="text-red-700 h-[24px]">{validationMessage}</div>

        <button type="submit" className="bg-green-700 text-white w-44 md:w-32 p-4 md:p-2 my-5 hover:bg-green-800 rounded-xl">
          LOGIN
        </button>
      </form>
    </div>
  );
}

export default LoginForm;
