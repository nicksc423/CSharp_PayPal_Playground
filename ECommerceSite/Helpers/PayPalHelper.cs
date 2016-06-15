using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace ECommerceSite.Helpers
{
    public static class PayPalHelper
    {
        public static List<SelectListItem> Months = new List<SelectListItem>() { 
            new SelectListItem() { Text="Jan", Value="01" },
            new SelectListItem() { Text="Feb", Value="02" },
            new SelectListItem() { Text="Mar", Value="03" },
            new SelectListItem() { Text="Apr", Value="04" },
            new SelectListItem() { Text="May", Value="05" },
            new SelectListItem() { Text="Jun", Value="06" },
            new SelectListItem() { Text="Jul", Value="07" },
            new SelectListItem() { Text="Aug", Value="08" },
            new SelectListItem() { Text="Sep", Value="09" },
            new SelectListItem() { Text="Oct", Value="10" },
            new SelectListItem() { Text="Nov", Value="11" },
            new SelectListItem() { Text="Dec", Value="12" }
        };

        public static SelectList Years = new SelectList(Enumerable.Range(DateTime.Today.Year, 20));

        public static List<SelectListItem> CreditCardTypes = new List<SelectListItem>() {
            new SelectListItem() { Text="Visa", Value="visa" },
            new SelectListItem() { Text="Mastercard", Value="mastercard" },
            new SelectListItem() { Text="Discover", Value="discover" },
            new SelectListItem() { Text="American Express", Value="amex" }
        };

        public static IEnumerable<SelectListItem> Countries = new List<SelectListItem>() {
            new SelectListItem() {Text="United States", Value = "US"},
            new SelectListItem() {Text="United Kingdom", Value = "UK"},
            new SelectListItem() {Text="Canada", Value = "CA"},
            new SelectListItem() {Text="Germany", Value = "DE"}
        };

        public static string getUsStates()
        {
            var data = new[]
            {
                new { key = "Alaska", value = "AK"},
                new { key = "Alabama", value = "AL"},
                new { key = "Arizona", value = "AZ"},
                new { key = "Arkansas", value = "AR"},
                new { key = "California", value = "CA"},
                new { key = "Colorado", value = "CO"},
                new { key = "Connecticut", value = "CT"},
                new { key = "District of Columbia", value = "DC"},
                new { key = "Delaware", value = "DE"},
                new { key = "Florida", value = "FL"},
                new { key = "Georgia", value = "GA"},
                new { key = "Hawaii", value = "HI"},
                new { key = "Idaho", value = "ID"},
                new { key = "Illinois", value = "IL"},
                new { key = "Indiana", value = "IN"},
                new { key = "Iowa", value = "IA"},
                new { key = "Kansas", value = "KS"},
                new { key = "Kentucky", value = "KY"},
                new { key = "Louisiana", value = "LA"},
                new { key = "Maine", value = "ME"},
                new { key = "Maryland", value = "MD"},
                new { key = "Massachusetts", value = "MA"},
                new { key = "Michigan", value = "MI"},
                new { key = "Minnesota", value = "MN"},
                new { key = "Mississippi", value = "MS"},
                new { key = "Missouri", value = "MO"},
                new { key = "Montana", value = "MT"},
                new { key = "Nebraska", value = "NE"},
                new { key = "Nevada", value = "NV"},
                new { key = "New Hampshire", value = "NH"},
                new { key = "New Jersey", value = "NJ"},
                new { key = "New Mexico", value = "NM"},
                new { key = "New York", value = "NY"},
                new { key = "North Carolina", value = "NC"},
                new { key = "North Dakota", value = "ND"},
                new { key = "Ohio", value = "OH"},
                new { key = "Oklahoma", value = "OK"},
                new { key = "Oregon", value = "OR"},
                new { key = "Pennsylvania", value = "PA"},
                new { key = "Rhode Island", value = "RI"},
                new { key = "South Carolina", value = "SC"},
                new { key = "South Dakota", value = "SD"},
                new { key = "Tennessee", value = "TN"},
                new { key = "Texas", value = "TX"},
                new { key = "Utah", value = "UT"},
                new { key = "Vermont", value = "VT"},
                new { key = "Virginia", value = "VA"},
                new { key = "Washington", value = "WA"},
                new { key = "West Virginia", value = "WV"},
                new { key = "Wisconsin", value = "WI"},
                new { key = "Wyoming", value = "WY"}
            };
            return JsonConvert.SerializeObject(data);
        }

        public static string getCaStates()
        {
            var data = new[]
            {
                new { key = "Alberta", value = "AB"},
                new { key = "British Columbia", value = "BC"},
                new { key = "Manitoba", value = "MB"},
                new { key = "New Brunswick", value = "NB"},
                new { key = "Newfoundland", value = "NL"},
                new { key = "Northwest Territories", value = "NT"},
                new { key = "Nova Scotia", value = "NS"},
                new { key = "Nunavut", value = "NU"},
                new { key = "Ontario", value = "ON"},
                new { key = "Prince Edward Island", value = "PE"},
                new { key = "Quebec", value = "QC"},
                new { key = "Saskatchewan", value = "SK"},
                new { key = "Yukon", value = "YT"}
            };  
            return JsonConvert.SerializeObject(data);
        }
    }
}