﻿using System;

namespace Festival.Web.Areas.Admin.ViewModels.TransferReservation
{
    public class TransferReservationListVM
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string MeetingPoint { get; set; }
    }
}
