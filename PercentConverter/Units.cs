/* This file is part of PercentConverter.
 * Copyright (c) 2023 Alexandr Shchukin
 * Corresponding email: alexonemoreemail@gmail.com
 *
 * PercentConverter is free software:
 * you can redistribute it and/or modify it under the terms of
 * the GNU General Public License as published by
 * the Free Software Foundation, version 3.
 *
 * PercentConverter is distributed in the hope that
 * it will be useful, but WITHOUT ANY WARRANTY; without even the implied
 * warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 * See the GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with PercentConverter.
 * If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PercentConverter
{
    public enum Units
    {
        WeightPercent,
        AtomicPercent,
        Other
    }

    public static class UnitsMethods
    {
        public static Units Swap(this Units unit)
        {
            return unit == Units.AtomicPercent ? Units.WeightPercent
                 : unit == Units.WeightPercent ? Units.AtomicPercent : Units.Other;
        }

        public static string GetString(this Units unit)
        {
            switch (unit)
            {
                case Units.WeightPercent:
                    return "All results in weight%";
                case Units.AtomicPercent:
                    return "All results in atomic%";
                default:
                    return string.Empty;
            }
        }
    }
}
