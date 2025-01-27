import PlantCard from "./PlantCard";

function PlantsByDate() {
  return (
    <div>
      <div className="text-3xl my-5 font-bold text-green-800">Today</div>
      <div className="flex flex-wrap gap-16">
        <PlantCard />
        <PlantCard />
      </div>
      <div className="text-3xl my-5 font-bold text-green-800">27.01.2025.</div>
      <div className="flex flex-wrap gap-16">
        <PlantCard />
        <PlantCard />
        <PlantCard />
      </div>
    </div>
  );
}

export default PlantsByDate;
