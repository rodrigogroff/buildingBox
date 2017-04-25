﻿using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public class Country
	{
		public long id { get; set; }
		public string stName { get; set; }
	}

	public class EnumCountry
	{
		public List<Country> lst = new List<Country>();

		public EnumCountry()
		{
			int t = 1;
			lst.Add(new Country { id = t++, stName = "Afghanistan" });
			lst.Add(new Country { id = t++, stName = "Albania" });
			lst.Add(new Country { id = t++, stName = "Algeria" });
			lst.Add(new Country { id = t++, stName = "American Samoa" });
			lst.Add(new Country { id = t++, stName = "Andorra" });
			lst.Add(new Country { id = t++, stName = "Angola" });
			lst.Add(new Country { id = t++, stName = "Anguilla" });
			lst.Add(new Country { id = t++, stName = "Antigua and Barbuda" });
			lst.Add(new Country { id = t++, stName = "Argentina" });
			lst.Add(new Country { id = t++, stName = "Armenia" });
			lst.Add(new Country { id = t++, stName = "Aruba" });
			lst.Add(new Country { id = t++, stName = "Australia" });
			lst.Add(new Country { id = t++, stName = "Austria" });
			lst.Add(new Country { id = t++, stName = "Azerbaijan" });
			lst.Add(new Country { id = t++, stName = "The Bahamas" });
			lst.Add(new Country { id = t++, stName = "Bahrain" });
			lst.Add(new Country { id = t++, stName = "Bangladesh" });
			lst.Add(new Country { id = t++, stName = "Barbados" });
			lst.Add(new Country { id = t++, stName = "Belarus" });
			lst.Add(new Country { id = t++, stName = "Belgium" });
			lst.Add(new Country { id = t++, stName = "Belize" });
			lst.Add(new Country { id = t++, stName = "Benin" });
			lst.Add(new Country { id = t++, stName = "Bermuda" });
			lst.Add(new Country { id = t++, stName = "Bhutan" });
			lst.Add(new Country { id = t++, stName = "Bolivia" });
			lst.Add(new Country { id = t++, stName = "Bosnia and Herzegovina" });
			lst.Add(new Country { id = t++, stName = "Botswana" });
			lst.Add(new Country { id = t++, stName = "Brazil" });
			lst.Add(new Country { id = t++, stName = "British Virgin Islands" });
			lst.Add(new Country { id = t++, stName = "Brunei" });
			lst.Add(new Country { id = t++, stName = "Bulgaria" });
			lst.Add(new Country { id = t++, stName = "Burkina Faso" });
			lst.Add(new Country { id = t++, stName = "Burundi" });
			lst.Add(new Country { id = t++, stName = "Cambodia" });
			lst.Add(new Country { id = t++, stName = "Cameroon" });
			lst.Add(new Country { id = t++, stName = "Canada" });
			lst.Add(new Country { id = t++, stName = "Cape Verde" });
			lst.Add(new Country { id = t++, stName = "Cayman Islands" });
			lst.Add(new Country { id = t++, stName = "Central African Republic" });
			lst.Add(new Country { id = t++, stName = "Chad" });
			lst.Add(new Country { id = t++, stName = "Chile" });
			lst.Add(new Country { id = t++, stName = "China (People's Republic of)" });
			lst.Add(new Country { id = t++, stName = "Christmas Island" });
			lst.Add(new Country { id = t++, stName = "Cocos Islands" });
			lst.Add(new Country { id = t++, stName = "Colombia" });
			lst.Add(new Country { id = t++, stName = "Comoros" });
			lst.Add(new Country { id = t++, stName = "Congo" });
			lst.Add(new Country { id = t++, stName = "Congo DR" });
			lst.Add(new Country { id = t++, stName = "Cook Islands" });
			lst.Add(new Country { id = t++, stName = "Costa Rica" });
			lst.Add(new Country { id = t++, stName = "Côte d'Ivoire" });
			lst.Add(new Country { id = t++, stName = "Croatia" });
			lst.Add(new Country { id = t++, stName = "Cuba" });
			lst.Add(new Country { id = t++, stName = "Curaçao" });
			lst.Add(new Country { id = t++, stName = "Cyprus" });
			lst.Add(new Country { id = t++, stName = "Czech Republic" });
			lst.Add(new Country { id = t++, stName = "Denmark" });
			lst.Add(new Country { id = t++, stName = "Djibouti" });
			lst.Add(new Country { id = t++, stName = "Dominica" });
			lst.Add(new Country { id = t++, stName = "Dominican Republic" });
			lst.Add(new Country { id = t++, stName = "East Timor" });
			lst.Add(new Country { id = t++, stName = "Ecuador" });
			lst.Add(new Country { id = t++, stName = "Egypt" });
			lst.Add(new Country { id = t++, stName = "El Salvador" });
			lst.Add(new Country { id = t++, stName = "Equatorial Guinea" });
			lst.Add(new Country { id = t++, stName = "Eritrea" });
			lst.Add(new Country { id = t++, stName = "Estonia" });
			lst.Add(new Country { id = t++, stName = "Ethiopia" });
			lst.Add(new Country { id = t++, stName = "Falkland Islands" });
			lst.Add(new Country { id = t++, stName = "Faroe Islands" });
			lst.Add(new Country { id = t++, stName = "Fiji" });
			lst.Add(new Country { id = t++, stName = "Finland" });
			lst.Add(new Country { id = t++, stName = "France" });
			lst.Add(new Country { id = t++, stName = "French Guiana" });
			lst.Add(new Country { id = t++, stName = "French Polynesia" });
			lst.Add(new Country { id = t++, stName = "Gabon" });
			lst.Add(new Country { id = t++, stName = "The Gambia" });
			lst.Add(new Country { id = t++, stName = "Georgia" });
			lst.Add(new Country { id = t++, stName = "Germany" });
			lst.Add(new Country { id = t++, stName = "Ghana" });
			lst.Add(new Country { id = t++, stName = "Gibraltar" });
			lst.Add(new Country { id = t++, stName = "Greece" });
			lst.Add(new Country { id = t++, stName = "Greenland" });
			lst.Add(new Country { id = t++, stName = "Grenada" });
			lst.Add(new Country { id = t++, stName = "Guadeloupe" });
			lst.Add(new Country { id = t++, stName = "Guam" });
			lst.Add(new Country { id = t++, stName = "Guatemala" });
			lst.Add(new Country { id = t++, stName = "Guernsey" });
			lst.Add(new Country { id = t++, stName = "Guinea" });
			lst.Add(new Country { id = t++, stName = "Guinea-Bissau" });
			lst.Add(new Country { id = t++, stName = "Guyana" });
			lst.Add(new Country { id = t++, stName = "Haiti" });
			lst.Add(new Country { id = t++, stName = "Honduras" });
			lst.Add(new Country { id = t++, stName = "Hong Kong" });
			lst.Add(new Country { id = t++, stName = "Hungary" });
			lst.Add(new Country { id = t++, stName = "Iceland" });
			lst.Add(new Country { id = t++, stName = "India" });
			lst.Add(new Country { id = t++, stName = "Indonesia" });
			lst.Add(new Country { id = t++, stName = "Iran" });
			lst.Add(new Country { id = t++, stName = "Iraq" });
			lst.Add(new Country { id = t++, stName = "Ireland" });
			lst.Add(new Country { id = t++, stName = "Isle of Man" });
			lst.Add(new Country { id = t++, stName = "Israel" });
			lst.Add(new Country { id = t++, stName = "Italy" });
			lst.Add(new Country { id = t++, stName = "Jamaica" });
			lst.Add(new Country { id = t++, stName = "Japan" });
			lst.Add(new Country { id = t++, stName = "Jersey" });
			lst.Add(new Country { id = t++, stName = "Jordan" });
			lst.Add(new Country { id = t++, stName = "Kazakhstan" });
			lst.Add(new Country { id = t++, stName = "Kenya" });
			lst.Add(new Country { id = t++, stName = "Kiribati" });
			lst.Add(new Country { id = t++, stName = "North Korea" });
			lst.Add(new Country { id = t++, stName = "South Korea" });
			lst.Add(new Country { id = t++, stName = "Kosovo" });
			lst.Add(new Country { id = t++, stName = "Kuwait" });
			lst.Add(new Country { id = t++, stName = "Kyrgyzstan" });
			lst.Add(new Country { id = t++, stName = "Laos" });
			lst.Add(new Country { id = t++, stName = "Latvia" });
			lst.Add(new Country { id = t++, stName = "Lebanon" });
			lst.Add(new Country { id = t++, stName = "Lesotho" });
			lst.Add(new Country { id = t++, stName = "Liberia" });
			lst.Add(new Country { id = t++, stName = "Libya" });
			lst.Add(new Country { id = t++, stName = "Liechtenstein" });
			lst.Add(new Country { id = t++, stName = "Lithuania" });
			lst.Add(new Country { id = t++, stName = "Luxembourg" });
			lst.Add(new Country { id = t++, stName = "Macedonia" });
			lst.Add(new Country { id = t++, stName = "Madagascar" });
			lst.Add(new Country { id = t++, stName = "Malawi" });
			lst.Add(new Country { id = t++, stName = "Malaysia" });
			lst.Add(new Country { id = t++, stName = "Maldives" });
			lst.Add(new Country { id = t++, stName = "Mali" });
			lst.Add(new Country { id = t++, stName = "Malta" });
			lst.Add(new Country { id = t++, stName = "Marshall Islands" });
			lst.Add(new Country { id = t++, stName = "Martinique" });
			lst.Add(new Country { id = t++, stName = "Mauritania" });
			lst.Add(new Country { id = t++, stName = "Mauritius" });
			lst.Add(new Country { id = t++, stName = "Mayotte" });
			lst.Add(new Country { id = t++, stName = "Mexico" });
			lst.Add(new Country { id = t++, stName = "Federated States of Micronesia" });
			lst.Add(new Country { id = t++, stName = "Moldova" });
			lst.Add(new Country { id = t++, stName = "Monaco" });
			lst.Add(new Country { id = t++, stName = "Mongolia" });
			lst.Add(new Country { id = t++, stName = "Montenegro" });
			lst.Add(new Country { id = t++, stName = "Montserrat" });
			lst.Add(new Country { id = t++, stName = "Morocco" });
			lst.Add(new Country { id = t++, stName = "Mozambique" });
			lst.Add(new Country { id = t++, stName = "Myanmar" });
			lst.Add(new Country { id = t++, stName = "Namibia" });
			lst.Add(new Country { id = t++, stName = "Nauru" });
			lst.Add(new Country { id = t++, stName = "Nepal" });
			lst.Add(new Country { id = t++, stName = "Netherlands" });
			lst.Add(new Country { id = t++, stName = "New Caledonia" });
			lst.Add(new Country { id = t++, stName = "New Zealand" });
			lst.Add(new Country { id = t++, stName = "Nicaragua" });
			lst.Add(new Country { id = t++, stName = "Niger" });
			lst.Add(new Country { id = t++, stName = "Nigeria" });
			lst.Add(new Country { id = t++, stName = "Niue" });
			lst.Add(new Country { id = t++, stName = "Norfolk Island" });
			lst.Add(new Country { id = t++, stName = "Northern Mariana Islands" });
			lst.Add(new Country { id = t++, stName = "Norway" });
			lst.Add(new Country { id = t++, stName = "Oman" });
			lst.Add(new Country { id = t++, stName = "Pakistan" });
			lst.Add(new Country { id = t++, stName = "Palau" });
			lst.Add(new Country { id = t++, stName = "Panama" });
			lst.Add(new Country { id = t++, stName = "Papua New Guinea" });
			lst.Add(new Country { id = t++, stName = "Paraguay" });
			lst.Add(new Country { id = t++, stName = "Peru" });
			lst.Add(new Country { id = t++, stName = "Philippines" });
			lst.Add(new Country { id = t++, stName = "Pitcairn Islands" });
			lst.Add(new Country { id = t++, stName = "Poland" });
			lst.Add(new Country { id = t++, stName = "Portugal" });
			lst.Add(new Country { id = t++, stName = "Puerto Rico" });
			lst.Add(new Country { id = t++, stName = "Qatar" });
			lst.Add(new Country { id = t++, stName = "Réunion" });
			lst.Add(new Country { id = t++, stName = "Romania" });
			lst.Add(new Country { id = t++, stName = "Russia" });
			lst.Add(new Country { id = t++, stName = "Rwanda" });
			lst.Add(new Country { id = t++, stName = "Sahrawi Arab Democratic Republic" });
			lst.Add(new Country { id = t++, stName = "Saint Barthélemy" });
			lst.Add(new Country { id = t++, stName = "Saint Helena, Ascension and Tristan da Cunha" });
			lst.Add(new Country { id = t++, stName = "Saint Kitts and Nevis" });
			lst.Add(new Country { id = t++, stName = "Saint Martin" });
			lst.Add(new Country { id = t++, stName = "Saint Lucia" });
			lst.Add(new Country { id = t++, stName = "Saint Pierre and Miquelon" });
			lst.Add(new Country { id = t++, stName = "Saint Vincent and the Grenadines" });
			lst.Add(new Country { id = t++, stName = "Samoa" });
			lst.Add(new Country { id = t++, stName = "San Marino" });
			lst.Add(new Country { id = t++, stName = "São Tomé and Príncipe" });
			lst.Add(new Country { id = t++, stName = "Saudi Arabia" });
			lst.Add(new Country { id = t++, stName = "Senegal" });
			lst.Add(new Country { id = t++, stName = "Serbia" });
			lst.Add(new Country { id = t++, stName = "Seychelles" });
			lst.Add(new Country { id = t++, stName = "Sierra Leone" });
			lst.Add(new Country { id = t++, stName = "Singapore" });
			lst.Add(new Country { id = t++, stName = "Sint Maarten" });
			lst.Add(new Country { id = t++, stName = "Slovakia" });
			lst.Add(new Country { id = t++, stName = "Slovenia" });
			lst.Add(new Country { id = t++, stName = "Solomon Islands" });
			lst.Add(new Country { id = t++, stName = "Somalia" });
			lst.Add(new Country { id = t++, stName = "South Africa" });
			lst.Add(new Country { id = t++, stName = "South Sudan" });
			lst.Add(new Country { id = t++, stName = "Spain" });
			lst.Add(new Country { id = t++, stName = "Sri Lanka" });
			lst.Add(new Country { id = t++, stName = "Sudan" });
		}

		public Country Get(long _id)
		{
			return lst.Where(y => y.id == _id).FirstOrDefault();
		}
	}
}
