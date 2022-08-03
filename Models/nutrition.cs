using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Nutrition
{
    [Key]
    public int ID { get; set; }
    public string Item { get; set; }
    public int Serving { get; set; }
    public int Calories { get; set; }
    public int Proteins { get; set; }
    public int Carbohydrates { get; set; }
    public int Fats { get; set; }
    public int Quantity { get; set; }
    public bool Today { get; set; }

    public string? _totals;
    public string Totals => _totals ??= GetTotalsString();

    public string GetTotalsString(){

        double totalcals = Calories * Quantity;
        double totalprot = Proteins * Quantity;
        double totalcarb = Carbohydrates * Quantity;
        double totalfats = Fats * Quantity;

        _totals = $"{totalcals} Calories {totalprot} Protein {totalcarb} Carbs {totalfats} Fat";
        return _totals;
    }
}