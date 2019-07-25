﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace downloadCounters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            string lastDownloaded = "?";

            for(int a=1; ; a++)
            {
                var ret = await DownloadFile(a, lastDownloaded);
                if (ret == "") break;
                lastDownloaded = ret;
            }
        }

        async Task<string> DownloadFile(int page, string lastString)
        {
            string weblink = "https://markets.ft.com/data/equities/ajax/updateScreenerResults?data=%5B%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCCountryCode%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCICBSectorCode%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCICBIndustryCode%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCMarketCap%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCBeta5Year%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCDividendYield%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCConsensusRecommendation%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCDXScoreBucket%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCPEExclXItemsTTM%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCInstPctHeld%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCBookValPerShareMRFY%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCCashPerShareTTM%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCCurrentRatio%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCCapSpendGrowth5y%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCNetIncomeGrowth5y%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCNetIncomePctChgYoY%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCPriceToBookMRQ%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCPriceToCashFlowTTM%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCPriceToSalesTTM%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCROAssets5yAvg%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCROAssetsTTM%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCROEquity5yAvg%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCROEquityTTM%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCROInvestment5yAvg%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCROInvestTTM%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCCurrEntVal%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCEmployees%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCNetIncTTM%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCRevenueTTM%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCPrice52wPctChg%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCEBITDAMarginTTM%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCGrossMargin%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCGrossMargin5yAvg%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCOperMarginTTM%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCProfitMargin5yAvg%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCProfitMarginPctTTM%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCEPSGrowth10Year%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCEPSGrowth5Year%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCRevenueGrowth10Year%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCRevenueGrowth5Year%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCRevenuePctChgYoY%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCAssetTurnoverTTM%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCInventoryTurnoverTTM%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCReceivTurnoverTTM%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCRevPerEmpTTM%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCDebtToCapitalMRQ%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCInterestCoverageTTM%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCPayoutRatioTTM%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%2C%7B%22ArgsOperator%22%3Anull%2C%22ValueOperator%22%3Anull%2C%22Arguments%22%3A%5B%5D%2C%22Clauses%22%3A%5B%5D%2C%22ClauseGroups%22%3A%5B%5D%2C%22Field%22%3A%22RCCQuickRatioMRQ%22%2C%22Identifiers%22%3Anull%2C%22Style%22%3Anull%7D%5D&page={0}&currencyCode=GBP&sort=%7B%22field%22%3A%22RCCFTStandardName%22%2C%22direction%22%3A%22ascending%22%7D";
            weblink = weblink.Replace("{0}", page.ToString());

            WebClient wc = new WebClient();
            string downloadText;
            try
            {
                downloadText = await wc.DownloadStringTaskAsync(weblink);
            }
            catch
            {
                SystemSounds.Asterisk.Play();
                Debug.WriteLine("Exception encountered");
                return "";
            }

            
            if (downloadText == lastString)
                return "";

            File.WriteAllText(page + ".txt", downloadText);

            return downloadText;
        }
    }
}
