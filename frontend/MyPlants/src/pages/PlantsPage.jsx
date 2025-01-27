import PlantCard from "../components/PlantCard";

function PlantsPage() {
  return (
    <div className="mx-10 lg:mx-20">
      <div className="my-5">
        <span className="text-3xl font-bold text-green-800 mr-5 align-baseline">All plants</span>

        <button className="bg-green-700 bg-opacity-50 hover:bg-opacity-70 text-white p-2 px-5 rounded-full">
          <span>Add</span>
          <span className="text-2xl">+</span>
        </button>
      </div>

      <div className="flex flex-wrap gap-16">
        <PlantCard />
        <PlantCard />
        <PlantCard />
        <PlantCard />
        <PlantCard />
      </div>
    </div>
  );
}

export default PlantsPage;
