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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace PercentConverter
{
    public class Table
    {
        private List<Spectrum> _data;
        private string[] _columnNames;

        public Table(string page)
        {
            var pageLower = page.ToLower();
            if (!pageLower.Contains("table"))
                return;

            var lines = pageLower
                .Split(new[] { @"<tr>", @"</tr>" }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToArray();

            _columnNames = lines
                .First()
                .Split(new[] { "<td>" }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(2)
                .Where(x => !x.Contains("total"))
                .Select(str => char.ToUpper(str[0]) + str.Substring(1))
                .ToArray();

            var atomicWeights = _columnNames.Select(e => Element.Table[e].AtomicWeight).ToArray();

            var initialUnits = lines
                .Where(x => x.Contains("results in"))
                .Select(x => x.Contains("weight")
                        ? Units.WeightPercent : x.Contains("atomic")
                        ? Units.AtomicPercent : Units.Other)
                .First();

            var culture = CultureInfo.CreateSpecificCulture("en-US");
            _data = lines
                .Where(x => x.Contains("yes"))
                .Select(x => x
                        .Split(new[] { "<td>" }, StringSplitOptions.RemoveEmptyEntries)
                        .Skip(2)
                        .Take(atomicWeights.Length)
                        .Select(a => double.Parse(a, culture))
                        .ToArray())
                .Select(x => new Spectrum(atomicWeights, x, initialUnits))
                .ToList();
        }

        public string MakeTable()
        {
            return MakeTable(x => x.PointAtomic, Units.AtomicPercent)
                + "\n\n"
                + MakeTable(x => x.PointWeight, Units.WeightPercent);
        }

        public string MakeTable(Func<Spectrum, double[]> selector, Units unit)
        {
            string sep = "\t";
            string lineSep = "\n";
            string res = "";
            res += "Spectrum" + sep;
            res += string.Join(sep, _columnNames);
            res += lineSep + lineSep;
            int i = 1;
            foreach (var row in _data)
            {
                res += (i++).ToString() + sep;
                res += string.Join(sep, selector(row).Select(x => x.ToString()).ToArray());
                res += lineSep;
            }
            res += lineSep;
            res += unit.GetString();
            res += lineSep;
            return res;
        }
    }
}
