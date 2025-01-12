import { configureStore } from "@reduxjs/toolkit";
import isLoggedInReducer from "./slices/isLoggedInSlice";

const store = configureStore({
  reducer: {
    isLoggedIn: isLoggedInReducer,
  },
});

export default store;
