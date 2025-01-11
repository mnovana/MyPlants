function LoginForm() {
  return (
    <div className="flex flex-col bg-green-100 bg-opacity-40 md:w-1/2 w-5/6 h-fit shadow-md gap-20 md:gap-10">
      <h1 className="text-3xl text-center m-5">Login</h1>

      <form className="flex-1 flex flex-col justify-evenly items-center gap-20 md:gap-10">
        <input type="text" placeholder="Email" className="p-4 md:p-2 rounded-xl md:w-2/3 w-5/6 shadow-inner" />
        <input type="password" placeholder="Password" className="p-4 md:p-2 rounded-xl md:w-2/3 w-5/6 shadow-innser" />

        <button type="submit" className="bg-green-700 text-white w-44 md:w-32 p-4 md:p-2 my-20 md:my-10 hover:bg-green-800 rounded-xl">
          LOGIN
        </button>
      </form>
    </div>
  );
}

export default LoginForm;
