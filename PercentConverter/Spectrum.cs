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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PercentConverter
{
    public class Spectrum
    {
        public List<double> PointAtomic { get; private set; }
        public List<double> PointWeight { get; private set; }

        public Spectrum(List<double> atomicWeights, List<double> values, Units initialUnits)
        {
            if (values.Count < atomicWeights.Count)
                throw new ArgumentException();                       

            PointAtomic = ConvertToAtomic(atomicWeights, values, initialUnits);
            PointWeight = ConvertToWeight(atomicWeights, values, initialUnits);
        }

        private List<double> ConvertToAtomic(List<double> atomicWeights, List<double> values, Units initialUnits)
        {
            if (initialUnits == Units.AtomicPercent)
                return values;
            else
                return Convert(atomicWeights, values, (a, b) => a / b);
        }

        private List<double> ConvertToWeight(List<double> atomicWeights, List<double> values, Units initialUnits)
        {
            if (initialUnits == Units.WeightPercent)
                return values;
            else
                return Convert(atomicWeights, values, (a, b) => a * b);
        }

        private List<double> Convert(List<double> atomicWeights, List<double> values,
            Func<double, double, double> op)
        {
            if (atomicWeights.Count != values.Count)
                throw new ArgumentException();
            var temp = values.Zip(atomicWeights, op);
            var sum = temp.Sum();
            if (sum <= 0)
                throw new Exception("Sum <= 0");
            return temp
                .Select(w => 100 * w / sum)
                .Select(x => Math.Round(x, 2))
                .ToList();
        }

    }
}
