export const createToppingsView = (
  allPizzaToppings,
  t,
  handleDeletePizzaTopping,
  handleAddPizzaTopping,
  selectedPizza
) => {
  const foundTopping = allPizzaToppings.filter(
    (pt) => pt.ToppingId == t.id && pt.PizzaId == selectedPizza
  );
  if (foundTopping.length != 0) {
    return (
      <article key={t.id}>
        <label>{t.name}</label>
        <input
          type="checkbox"
          defaultChecked
          onClick={() => {
            handleDeletePizzaTopping(t.id, selectedPizza);
          }}
        />
      </article>
    );
  } else {
    return (
      <article key={t.id}>
        <label>
          {t.name}
          <input
            type="checkbox"
            onClick={() => {
              handleAddPizzaTopping(t.id, selectedPizza);
            }}
          />
        </label>
      </article>
    );
  }
};
