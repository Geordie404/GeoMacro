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
    public double Quantity { get; set; }
    public bool Today { get; set; }

    public string? _date;
    public string Date => _date ??= GetDate();

    public string GetDate(){
        _date = DateTime.Now.ToString("d");
        return _date;
    }


    public string? _totals;
    public string Totals => _totals ??= GetTotalsString();

    public string GetTotalsString(){
        _totals = $"{Calories} Calories {Proteins} Protein {Carbohydrates} Carbs {Fats} Fat";
        return _totals;
    }

    public string? _log;
    public string Log => _log ??= GetLog();

    public string GetLog(){
        _log = $"{Date} | {Item} | {Totals}";
        return _log;
    }

}