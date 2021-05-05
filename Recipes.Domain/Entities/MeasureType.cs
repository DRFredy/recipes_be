﻿using System.ComponentModel.DataAnnotations;

namespace Recipes.Domain.Entities
{
  /// <summary>
  /// MeasureType entity
  /// </summary>
  public class MeasureType
  {
    /// <summary>
    /// MeasureType Id
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// MeasureType Name
    /// </summary>
    [Required] public string Name { get; set; }
  }
}