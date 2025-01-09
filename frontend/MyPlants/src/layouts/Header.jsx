import gardenerImg from "../assets/gardener.png";

function Header() {
  return (
    <div className="flex justify-between p-10">
      <div>
        <div className="text-6xl font-bold text-green-800">My Plants</div>
        <div className="text-xl tracking-wide">Track plants and their watering schedule!</div>
      </div>

      <img src={gardenerImg} className="h-28" />
    </div>
  );
}

export default Header;
