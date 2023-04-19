namespace MyRecipesLib.Model;

public struct Ingredient
{
    /*
     * <summary>
     * The identifier of the ingredient.
     */
    public string Id { get; set; } = "water";

    /*
     * <summary> 
     * The name of the ingredient.
     * </summary>
     */
    public string Name { get; set; } = string.Empty;

    /*
     * <summary> 
     * The quantity of the ingredient.
     * </summary>
     */
    public int Quantity { get; set; } = 0;

    /*
     * <summary> 
     * The unit of the ingredient.
     * </summary>
     */
    public string Unit { get; set; } = string.Empty;

    /*
     * <summary> 
     * Any notes about the ingredient.
     * </summary>
     */
    public string Notes { get; set; } = string.Empty;

    /*
     * <summary> 
     * Constructor for the Ingredient struct.
     * </summary>
     * <param name="name">The name of the ingredient.</param>
     * <param name="quantity">The quantity of the ingredient.</param>
     * <param name="unit">The unit of the ingredient.</param>
     * <param name="notes">Any notes about the ingredient.</param>
     */
    public Ingredient(string id, string name, int quantity, string unit, string notes)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        Unit = unit;
        Notes = notes;
    }

    /*
     * <summary> 
     * Returns a string representation of the ingredient.
     * </summary>
     * <returns>A string representation of the ingredient.</returns>
     */
    public override string ToString()
    {
        return string.Format("{0} {1} {2} {3}", Name, Quantity, Unit, Notes);
    }
}