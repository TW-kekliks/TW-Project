using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.Domain.Entities.Enums
{
    public enum Services
    {
        [Description("Узи глаза")]
        УзиГлаза,
        [Description("Коррекция зрения")]
        КорреккцияЗрения,
        [Description("Лечение катаркты")]
        ЛечениеКатаракты,
        [Description("Консультация")]
        Консультация
    }
}
