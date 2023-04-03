using System;
using System;
using eUseControl.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUseControl.Domain.Entities.User
{
    public class UDbTable
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
