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
    public class Element
    {
        public static Dictionary<string, Element> Table {get; private set;}

        static Element()
        {
            Table = new Dictionary<string, Element>()
            {
                { "H", new Element(1, "H", "Hydrogen", 1.00794) },
                { "He", new Element(2, "He", "Helium", 4.002602) },
                { "Li", new Element(3, "Li", "Lithium", 6.941) },
                { "Be", new Element(4, "Be", "Beryllium", 9.012182) },
                { "B", new Element(5, "B", "Boron", 10.811) },
                { "C", new Element(6, "C", "Carbon", 12.0107) },
                { "N", new Element(7, "N", "Nitrogen", 14.00674) },
                { "O", new Element(8, "O", "Oxygen", 15.9994) },
                { "F", new Element(9, "F", "Fluorine", 18.9984032) },
                { "Ne", new Element(10, "Ne", "Neon", 20.1797) },
                { "Na", new Element(11, "Na", "Sodium", 22.98977) },
                { "Mg", new Element(12, "Mg", "Magnesium", 24.305) },
                { "Al", new Element(13, "Al", "Aluminum", 26.981538) },
                { "Si", new Element(14, "Si", "Silicon", 28.0855) },
                { "P", new Element(15, "P", "Phosphorus", 30.973762) },
                { "S", new Element(16, "S", "Sulfur", 32.066) },
                { "Cl", new Element(17, "Cl", "Chlorine", 35.4527) },
                { "Ar", new Element(18, "Ar", "Argon", 39.948) },
                { "K", new Element(19, "K", "Potassium", 39.0983) },
                { "Ca", new Element(20, "Ca", "Calcium", 40.078) },
                { "Sc", new Element(21, "Sc", "Scandium", 44.95591) },
                { "Ti", new Element(22, "Ti", "Titanium", 47.867) },
                { "V", new Element(23, "V", "Vanadium", 50.9415) },
                { "Cr", new Element(24, "Cr", "Chromium", 51.9961) },
                { "Mn", new Element(25, "Mn", "Manganese", 54.938049) },
                { "Fe", new Element(26, "Fe", "Iron", 55.845) },
                { "Co", new Element(27, "Co", "Cobalt", 58.9332) },
                { "Ni", new Element(28, "Ni", "Nickel", 58.6934) },
                { "Cu", new Element(29, "Cu", "Copper", 63.546) },
                { "Zn", new Element(30, "Zn", "Zinc", 65.39) },
                { "Ga", new Element(31, "Ga", "Gallium", 69.723) },
                { "Ge", new Element(32, "Ge", "Germanium", 72.61) },
                { "As", new Element(33, "As", "Arsenic", 74.9216) },
                { "Se", new Element(34, "Se", "Selenium", 78.96) },
                { "Br", new Element(35, "Br", "Bromine", 79.904) },
                { "Kr", new Element(36, "Kr", "Krypton", 83.8) },
                { "Rb", new Element(37, "Rb", "Rubidium", 85.4678) },
                { "Sr", new Element(38, "Sr", "Strontium", 87.62) },
                { "Y", new Element(39, "Y", "Yttrium", 88.90585) },
                { "Zr", new Element(40, "Zr", "Zirconium", 91.224) },
                { "Nb", new Element(41, "Nb", "Niobium", 92.90638) },
                { "Mo", new Element(42, "Mo", "Molybdenum", 95.94) },
                { "Tc", new Element(43, "Tc", "Technetium", 98) },
                { "Ru", new Element(44, "Ru", "Ruthenium", 101.07) },
                { "Rh", new Element(45, "Rh", "Rhodium", 102.9055) },
                { "Pd", new Element(46, "Pd", "Palladium", 106.42) },
                { "Ag", new Element(47, "Ag", "Silver", 107.8682) },
                { "Cd", new Element(48, "Cd", "Cadmium", 112.411) },
                { "In", new Element(49, "In", "Indium", 114.818) },
                { "Sn", new Element(50, "Sn", "Tin", 118.71) },
                { "Sb", new Element(51, "Sb", "Antimony", 121.76) },
                { "Te", new Element(52, "Te", "Tellurium", 127.6) },
                { "I", new Element(53, "I", "Iodine", 126.90447) },
                { "Xe", new Element(54, "Xe", "Xenon", 131.29) },
                { "Cs", new Element(55, "Cs", "Cesium", 132.90545) },
                { "Ba", new Element(56, "Ba", "Barium", 137.327) },
                { "La", new Element(57, "La", "Lanthanum", 138.9055) },
                { "Ce", new Element(58, "Ce", "Cerium", 140.116) },
                { "Pr", new Element(59, "Pr", "Praseodymium", 140.90765) },
                { "Nd", new Element(60, "Nd", "Neodymium", 144.24) },
                { "Pm", new Element(61, "Pm", "Promethium", 145) },
                { "Sm", new Element(62, "Sm", "Samarium", 150.36) },
                { "Eu", new Element(63, "Eu", "Europium", 151.964) },
                { "Gd", new Element(64, "Gd", "Gadolinium", 157.25) },
                { "Tb", new Element(65, "Tb", "Terbium", 158.92534) },
                { "Dy", new Element(66, "Dy", "Dysprosium", 162.5) },
                { "Ho", new Element(67, "Ho", "Holmium", 164.93032) },
                { "Er", new Element(68, "Er", "Erbium", 167.26) },
                { "Tm", new Element(69, "Tm", "Thulium", 168.93421) },
                { "Yb", new Element(70, "Yb", "Ytterbium", 173.04) },
                { "Lu", new Element(71, "Lu", "Lutetium", 174.967) },
                { "Hf", new Element(72, "Hf", "Hafnium", 178.49) },
                { "Ta", new Element(73, "Ta", "Tantalum", 180.9479) },
                { "W", new Element(74, "W", "Tungsten", 183.84) },
                { "Re", new Element(75, "Re", "Rhenium", 186.207) },
                { "Os", new Element(76, "Os", "Osmium", 190.23) },
                { "Ir", new Element(77, "Ir", "Iridium", 192.217) },
                { "Pt", new Element(78, "Pt", "Platinum", 195.078) },
                { "Au", new Element(79, "Au", "Gold", 196.96655) },
                { "Hg", new Element(80, "Hg", "Mercury", 200.59) },
                { "Tl", new Element(81, "Tl", "Thallium", 204.3833) },
                { "Pb", new Element(82, "Pb", "Lead", 207.2) },
                { "Bi", new Element(83, "Bi", "Bismuth", 208.98038) },
                { "Po", new Element(84, "Po", "Polonium", 209) },
                { "At", new Element(85, "At", "Astatine", 210) },
                { "Rn", new Element(86, "Rn", "Radon", 222) },
                { "Fr", new Element(87, "Fr", "Francium", 223) },
                { "Ra", new Element(88, "Ra", "Radium", 226.0254) },
                { "Ac", new Element(89, "Ac", "Actinium", 227.0278) },
                { "Th", new Element(90, "Th", "Thorium", 232.0381) },
                { "Pa", new Element(91, "Pa", "Protactinium", 231.03588) },
                { "U", new Element(92, "U", "Uranium", 238.0289) },
                { "Np", new Element(93, "Np", "Neptunium", 237.0482) },
                { "Pu", new Element(94, "Pu", "Plutonium", 244) },
                { "Am", new Element(95, "Am", "Americium", 243) },
                { "Cm", new Element(96, "Cm", "Curium", 247) },
                { "Bk", new Element(97, "Bk", "Berkelium", 247) },
                { "Cf", new Element(98, "Cf", "Californium", 251) },
                { "Es", new Element(99, "Es", "Einsteinium", 252) },
                { "Fm", new Element(100, "Fm", "Fermium", 257) },
                { "Md", new Element(101, "Md", "Mendelevium", 258) },
                { "No", new Element(102, "No", "Nobelium", 259) },
                { "Lr", new Element(103, "Lr", "Lawrencium", 260) },
                { "Unq", new Element(104, "Unq", "(Unnilquadium)", 261) },
                { "Unp", new Element(105, "Unp", "(Unnilpentium)", 262) },
                { "Unh", new Element(106, "Unh", "(Unnilhexium)", 263) },
                { "D", new Element(1, "D", "Deuterium", 2.014101778) },
                { "T", new Element(1, "T", "Tritium", 3.01604928) },
            };
        }

        public int AtomicNumber { get; private set; }
        public string Symbol { get; private set; }
        public string Name { get; private set; }
        public double AtomicWeight{ get; private set; }
        public Element(int atomicNumber, string symbol, string name, double atomicWeight)
        {
            AtomicNumber = atomicNumber;
            Symbol = symbol;
            Name = name;
            AtomicWeight = atomicWeight;
        }
    }
}
