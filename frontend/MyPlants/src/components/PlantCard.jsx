import ficusImg from "../assets/plants/1.png";
import editIconImg from "../assets/edit.png";
import { useLocation } from "react-router-dom";

function PlantCard() {
  const location = useLocation();

  return (
    <div className="flex flex-col items-center">
      <div className="flex shadow-lg">
        <div className="bg-[#FFD3AD]">
          <img src={ficusImg} width={150} />
        </div>
        <div className="p-3">
          Last watering: 03.01.2025.
          <br />
          19 days ago
          <br />
          <br />
          <span className="text-red-600">5 days late!</span>
          <br />
          <br />
          <br />
          <button className="bg-[#8BC7FF] text-white p-2 px-10 hover:bg-opacity-70">WATER</button>
          {location.pathname == "/plants" && (
            <button className="ml-5">
              <img className="w-12 inline hover:opacity-70" src={editIconImg} />
            </button>
          )}
        </div>
      </div>
      <div className="text-xl mt-3">Ficus</div>
    </div>
  );
}

export default PlantCard;
