import gardenerImg from "../assets/gardener.png";

function Header() {
  return (
    <div className="flex justify-between">
      <div>
        <div className="text-3xl font-bold text-green-900">My Plants</div>
        <div>Track plants and their watering schedule!</div>
      </div>

      <img src={gardenerImg} />
    </div>
  );
}

export default Header;
