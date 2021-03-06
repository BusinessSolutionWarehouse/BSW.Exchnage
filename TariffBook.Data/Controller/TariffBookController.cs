using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TariffBook.Data
{
	public partial class TariffBookController : List<TariffBookModel>, IController
	{
		public bool Get(TariffBookModel model, ref string msg)
		{
			return Get(model, null, null, ref msg);
		}

		public bool Get(TariffBookModel model, TariffBookModel.Fields? sortByField, SortOrder? sortOrder, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (model.LastUpdateDT.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@LastUpdateDT", model.LastUpdateDT.Value, SqlDbType.DateTime));

				if (model.s1P1Duty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s1P1Duty", model.s1P1Duty.Value, SqlDbType.Decimal));

				if (!string.IsNullOrEmpty(model.s1P2ACode))
					listParameters.Add(ControllerManager.CreateParameter("@s1P2ACode", model.s1P2ACode, SqlDbType.VarChar));

				if (model.s1P2ADuty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s1P2ADuty", model.s1P2ADuty.Value, SqlDbType.Decimal));

				if (model.s1P2BDuty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s1P2BDuty", model.s1P2BDuty.Value, SqlDbType.Decimal));

				if (!string.IsNullOrEmpty(model.s1P3ACode))
					listParameters.Add(ControllerManager.CreateParameter("@s1P3ACode", model.s1P3ACode, SqlDbType.VarChar));

				if (model.s1P3ADuty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s1P3ADuty", model.s1P3ADuty.Value, SqlDbType.Decimal));

				if (!string.IsNullOrEmpty(model.s1P3BCode))
					listParameters.Add(ControllerManager.CreateParameter("@s1P3BCode", model.s1P3BCode, SqlDbType.VarChar));

				if (model.s1P3BDuty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s1P3BDuty", model.s1P3BDuty.Value, SqlDbType.Decimal));

				if (!string.IsNullOrEmpty(model.s1P3CCode))
					listParameters.Add(ControllerManager.CreateParameter("@s1P3CCode", model.s1P3CCode, SqlDbType.VarChar));

				if (model.s1P3CDuty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s1P3CDuty", model.s1P3CDuty.Value, SqlDbType.Decimal));

				if (!string.IsNullOrEmpty(model.s1P3DCode))
					listParameters.Add(ControllerManager.CreateParameter("@s1P3DCode", model.s1P3DCode, SqlDbType.VarChar));

				if (model.s1P3DDuty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s1P3DDuty", model.s1P3DDuty.Value, SqlDbType.Decimal));

				if (model.s1P5ADuty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s1P5ADuty", model.s1P5ADuty.Value, SqlDbType.Decimal));

				if (model.s1P5BDuty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s1P5BDuty", model.s1P5BDuty.Value, SqlDbType.Decimal));

				if (model.s2P1Duty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s2P1Duty", model.s2P1Duty.Value, SqlDbType.Decimal));

				if (!string.IsNullOrEmpty(model.s2P1DutyCode))
					listParameters.Add(ControllerManager.CreateParameter("@s2P1DutyCode", model.s2P1DutyCode, SqlDbType.VarChar));

				if (model.s2P2Duty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s2P2Duty", model.s2P2Duty.Value, SqlDbType.Decimal));

				if (!string.IsNullOrEmpty(model.s2P2DutyCode))
					listParameters.Add(ControllerManager.CreateParameter("@s2P2DutyCode", model.s2P2DutyCode, SqlDbType.VarChar));

				if (model.s2P3Duty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s2P3Duty", model.s2P3Duty.Value, SqlDbType.Decimal));

				if (!string.IsNullOrEmpty(model.s2P3DutyCode))
					listParameters.Add(ControllerManager.CreateParameter("@s2P3DutyCode", model.s2P3DutyCode, SqlDbType.VarChar));

				if (!string.IsNullOrEmpty(model.TariffCode))
					listParameters.Add(ControllerManager.CreateParameter("@TariffCode", model.TariffCode, SqlDbType.VarChar));

				if (model.TariffStatusID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@TariffStatusID", model.TariffStatusID.Value, SqlDbType.TinyInt));

				if (model.TotalDue.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@TotalDue", model.TotalDue.Value, SqlDbType.Decimal));

				if (model.TotalDuties.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@TotalDuties", model.TotalDuties.Value, SqlDbType.Decimal));

				if (model.VatValue.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@VatValue", model.VatValue.Value, SqlDbType.Decimal));

				if (sortByField.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortByField", sortByField.Value.ToString(), SqlDbType.VarChar));

				if (sortOrder.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortOrder", sortOrder.Value, SqlDbType.SmallInt));

				result = ControllerManager.ExecuteSP("TariffBookGet", listParameters, this, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Insert(TariffBookModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@LastUpdateDT", model.LastUpdateDT, SqlDbType.DateTime));
				listParameters.Add(ControllerManager.CreateParameter("@s1P1Duty", model.s1P1Duty, SqlDbType.Decimal));
				listParameters.Add(ControllerManager.CreateParameter("@s1P2ACode", model.s1P2ACode, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@s1P2ADuty", model.s1P2ADuty, SqlDbType.Decimal));
				listParameters.Add(ControllerManager.CreateParameter("@s1P2BDuty", model.s1P2BDuty, SqlDbType.Decimal));
				listParameters.Add(ControllerManager.CreateParameter("@s1P3ACode", model.s1P3ACode, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@s1P3ADuty", model.s1P3ADuty, SqlDbType.Decimal));
				listParameters.Add(ControllerManager.CreateParameter("@s1P3BCode", model.s1P3BCode, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@s1P3BDuty", model.s1P3BDuty, SqlDbType.Decimal));
				listParameters.Add(ControllerManager.CreateParameter("@s1P3CCode", model.s1P3CCode, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@s1P3CDuty", model.s1P3CDuty, SqlDbType.Decimal));
				listParameters.Add(ControllerManager.CreateParameter("@s1P3DCode", model.s1P3DCode, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@s1P3DDuty", model.s1P3DDuty, SqlDbType.Decimal));
				listParameters.Add(ControllerManager.CreateParameter("@s1P5ADuty", model.s1P5ADuty, SqlDbType.Decimal));
				listParameters.Add(ControllerManager.CreateParameter("@s1P5BDuty", model.s1P5BDuty, SqlDbType.Decimal));
				listParameters.Add(ControllerManager.CreateParameter("@s2P1Duty", model.s2P1Duty, SqlDbType.Decimal));
				listParameters.Add(ControllerManager.CreateParameter("@s2P1DutyCode", model.s2P1DutyCode, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@s2P2Duty", model.s2P2Duty, SqlDbType.Decimal));
				listParameters.Add(ControllerManager.CreateParameter("@s2P2DutyCode", model.s2P2DutyCode, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@s2P3Duty", model.s2P3Duty, SqlDbType.Decimal));
				listParameters.Add(ControllerManager.CreateParameter("@s2P3DutyCode", model.s2P3DutyCode, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@TariffStatusID", model.TariffStatusID, SqlDbType.TinyInt));
				listParameters.Add(ControllerManager.CreateParameter("@TotalDue", model.TotalDue, SqlDbType.Decimal));
				listParameters.Add(ControllerManager.CreateParameter("@TotalDuties", model.TotalDuties, SqlDbType.Decimal));
				listParameters.Add(ControllerManager.CreateParameter("@VatValue", model.VatValue, SqlDbType.Decimal));
                listParameters.Add(ControllerManager.CreateParameter("@TariffCode", model.TariffCode, SqlDbType.VarChar));

				object value = null;

				result = ControllerManager.ExecuteSPScalar("TariffBookInsert", listParameters, ref value, ref msg);

				if (result)
					model.TariffCode = ControllerManager.Converter.ToString(value);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Update(TariffBookModel model, bool dynamicUpdate, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@TariffCode", model.TariffCode, SqlDbType.VarChar));

				if (dynamicUpdate)
				{
					if (model.LastUpdateDT.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@LastUpdateDT", model.LastUpdateDT.Value, SqlDbType.DateTime));

					if (model.s1P1Duty.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@s1P1Duty", model.s1P1Duty.Value, SqlDbType.Decimal));

					if (!string.IsNullOrEmpty(model.s1P2ACode))
						listParameters.Add(ControllerManager.CreateParameter("@s1P2ACode", model.s1P2ACode, SqlDbType.VarChar));

					if (model.s1P2ADuty.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@s1P2ADuty", model.s1P2ADuty.Value, SqlDbType.Decimal));

					if (model.s1P2BDuty.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@s1P2BDuty", model.s1P2BDuty.Value, SqlDbType.Decimal));

					if (!string.IsNullOrEmpty(model.s1P3ACode))
						listParameters.Add(ControllerManager.CreateParameter("@s1P3ACode", model.s1P3ACode, SqlDbType.VarChar));

					if (model.s1P3ADuty.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@s1P3ADuty", model.s1P3ADuty.Value, SqlDbType.Decimal));

					if (!string.IsNullOrEmpty(model.s1P3BCode))
						listParameters.Add(ControllerManager.CreateParameter("@s1P3BCode", model.s1P3BCode, SqlDbType.VarChar));

					if (model.s1P3BDuty.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@s1P3BDuty", model.s1P3BDuty.Value, SqlDbType.Decimal));

					if (!string.IsNullOrEmpty(model.s1P3CCode))
						listParameters.Add(ControllerManager.CreateParameter("@s1P3CCode", model.s1P3CCode, SqlDbType.VarChar));

					if (model.s1P3CDuty.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@s1P3CDuty", model.s1P3CDuty.Value, SqlDbType.Decimal));

					if (!string.IsNullOrEmpty(model.s1P3DCode))
						listParameters.Add(ControllerManager.CreateParameter("@s1P3DCode", model.s1P3DCode, SqlDbType.VarChar));

					if (model.s1P3DDuty.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@s1P3DDuty", model.s1P3DDuty.Value, SqlDbType.Decimal));

					if (model.s1P5ADuty.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@s1P5ADuty", model.s1P5ADuty.Value, SqlDbType.Decimal));

					if (model.s1P5BDuty.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@s1P5BDuty", model.s1P5BDuty.Value, SqlDbType.Decimal));

					if (model.s2P1Duty.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@s2P1Duty", model.s2P1Duty.Value, SqlDbType.Decimal));

					if (!string.IsNullOrEmpty(model.s2P1DutyCode))
						listParameters.Add(ControllerManager.CreateParameter("@s2P1DutyCode", model.s2P1DutyCode, SqlDbType.VarChar));

					if (model.s2P2Duty.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@s2P2Duty", model.s2P2Duty.Value, SqlDbType.Decimal));

					if (!string.IsNullOrEmpty(model.s2P2DutyCode))
						listParameters.Add(ControllerManager.CreateParameter("@s2P2DutyCode", model.s2P2DutyCode, SqlDbType.VarChar));

					if (model.s2P3Duty.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@s2P3Duty", model.s2P3Duty.Value, SqlDbType.Decimal));

					if (!string.IsNullOrEmpty(model.s2P3DutyCode))
						listParameters.Add(ControllerManager.CreateParameter("@s2P3DutyCode", model.s2P3DutyCode, SqlDbType.VarChar));

					if (model.TariffStatusID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@TariffStatusID", model.TariffStatusID.Value, SqlDbType.TinyInt));

					if (model.TotalDue.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@TotalDue", model.TotalDue.Value, SqlDbType.Decimal));

					if (model.TotalDuties.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@TotalDuties", model.TotalDuties.Value, SqlDbType.Decimal));

					if (model.VatValue.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@VatValue", model.VatValue.Value, SqlDbType.Decimal));

				}
				else
				{
					listParameters.Add(ControllerManager.CreateParameter("@LastUpdateDT", model.LastUpdateDT, SqlDbType.DateTime));
					listParameters.Add(ControllerManager.CreateParameter("@s1P1Duty", model.s1P1Duty, SqlDbType.Decimal));
					listParameters.Add(ControllerManager.CreateParameter("@s1P2ACode", model.s1P2ACode, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@s1P2ADuty", model.s1P2ADuty, SqlDbType.Decimal));
					listParameters.Add(ControllerManager.CreateParameter("@s1P2BDuty", model.s1P2BDuty, SqlDbType.Decimal));
					listParameters.Add(ControllerManager.CreateParameter("@s1P3ACode", model.s1P3ACode, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@s1P3ADuty", model.s1P3ADuty, SqlDbType.Decimal));
					listParameters.Add(ControllerManager.CreateParameter("@s1P3BCode", model.s1P3BCode, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@s1P3BDuty", model.s1P3BDuty, SqlDbType.Decimal));
					listParameters.Add(ControllerManager.CreateParameter("@s1P3CCode", model.s1P3CCode, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@s1P3CDuty", model.s1P3CDuty, SqlDbType.Decimal));
					listParameters.Add(ControllerManager.CreateParameter("@s1P3DCode", model.s1P3DCode, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@s1P3DDuty", model.s1P3DDuty, SqlDbType.Decimal));
					listParameters.Add(ControllerManager.CreateParameter("@s1P5ADuty", model.s1P5ADuty, SqlDbType.Decimal));
					listParameters.Add(ControllerManager.CreateParameter("@s1P5BDuty", model.s1P5BDuty, SqlDbType.Decimal));
					listParameters.Add(ControllerManager.CreateParameter("@s2P1Duty", model.s2P1Duty, SqlDbType.Decimal));
					listParameters.Add(ControllerManager.CreateParameter("@s2P1DutyCode", model.s2P1DutyCode, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@s2P2Duty", model.s2P2Duty, SqlDbType.Decimal));
					listParameters.Add(ControllerManager.CreateParameter("@s2P2DutyCode", model.s2P2DutyCode, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@s2P3Duty", model.s2P3Duty, SqlDbType.Decimal));
					listParameters.Add(ControllerManager.CreateParameter("@s2P3DutyCode", model.s2P3DutyCode, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@TariffStatusID", model.TariffStatusID, SqlDbType.TinyInt));
					listParameters.Add(ControllerManager.CreateParameter("@TotalDue", model.TotalDue, SqlDbType.Decimal));
					listParameters.Add(ControllerManager.CreateParameter("@TotalDuties", model.TotalDuties, SqlDbType.Decimal));
					listParameters.Add(ControllerManager.CreateParameter("@VatValue", model.VatValue, SqlDbType.Decimal));
				}

				listParameters.Add(ControllerManager.CreateParameter("@CheckNull", dynamicUpdate ? 1 : 0, SqlDbType.Bit));

				result = ControllerManager.ExecuteSP("TariffBookUpdate", listParameters, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Delete(TariffBookModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (model.LastUpdateDT.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@LastUpdateDT", model.LastUpdateDT.Value, SqlDbType.DateTime));

				if (model.s1P1Duty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s1P1Duty", model.s1P1Duty.Value, SqlDbType.Decimal));

				if (!string.IsNullOrEmpty(model.s1P2ACode))
					listParameters.Add(ControllerManager.CreateParameter("@s1P2ACode", model.s1P2ACode, SqlDbType.VarChar));

				if (model.s1P2ADuty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s1P2ADuty", model.s1P2ADuty.Value, SqlDbType.Decimal));

				if (model.s1P2BDuty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s1P2BDuty", model.s1P2BDuty.Value, SqlDbType.Decimal));

				if (!string.IsNullOrEmpty(model.s1P3ACode))
					listParameters.Add(ControllerManager.CreateParameter("@s1P3ACode", model.s1P3ACode, SqlDbType.VarChar));

				if (model.s1P3ADuty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s1P3ADuty", model.s1P3ADuty.Value, SqlDbType.Decimal));

				if (!string.IsNullOrEmpty(model.s1P3BCode))
					listParameters.Add(ControllerManager.CreateParameter("@s1P3BCode", model.s1P3BCode, SqlDbType.VarChar));

				if (model.s1P3BDuty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s1P3BDuty", model.s1P3BDuty.Value, SqlDbType.Decimal));

				if (!string.IsNullOrEmpty(model.s1P3CCode))
					listParameters.Add(ControllerManager.CreateParameter("@s1P3CCode", model.s1P3CCode, SqlDbType.VarChar));

				if (model.s1P3CDuty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s1P3CDuty", model.s1P3CDuty.Value, SqlDbType.Decimal));

				if (!string.IsNullOrEmpty(model.s1P3DCode))
					listParameters.Add(ControllerManager.CreateParameter("@s1P3DCode", model.s1P3DCode, SqlDbType.VarChar));

				if (model.s1P3DDuty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s1P3DDuty", model.s1P3DDuty.Value, SqlDbType.Decimal));

				if (model.s1P5ADuty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s1P5ADuty", model.s1P5ADuty.Value, SqlDbType.Decimal));

				if (model.s1P5BDuty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s1P5BDuty", model.s1P5BDuty.Value, SqlDbType.Decimal));

				if (model.s2P1Duty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s2P1Duty", model.s2P1Duty.Value, SqlDbType.Decimal));

				if (!string.IsNullOrEmpty(model.s2P1DutyCode))
					listParameters.Add(ControllerManager.CreateParameter("@s2P1DutyCode", model.s2P1DutyCode, SqlDbType.VarChar));

				if (model.s2P2Duty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s2P2Duty", model.s2P2Duty.Value, SqlDbType.Decimal));

				if (!string.IsNullOrEmpty(model.s2P2DutyCode))
					listParameters.Add(ControllerManager.CreateParameter("@s2P2DutyCode", model.s2P2DutyCode, SqlDbType.VarChar));

				if (model.s2P3Duty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@s2P3Duty", model.s2P3Duty.Value, SqlDbType.Decimal));

				if (!string.IsNullOrEmpty(model.s2P3DutyCode))
					listParameters.Add(ControllerManager.CreateParameter("@s2P3DutyCode", model.s2P3DutyCode, SqlDbType.VarChar));

				if (!string.IsNullOrEmpty(model.TariffCode))
					listParameters.Add(ControllerManager.CreateParameter("@TariffCode", model.TariffCode, SqlDbType.VarChar));

				if (model.TariffStatusID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@TariffStatusID", model.TariffStatusID.Value, SqlDbType.TinyInt));

				if (model.TotalDue.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@TotalDue", model.TotalDue.Value, SqlDbType.Decimal));

				if (model.TotalDuties.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@TotalDuties", model.TotalDuties.Value, SqlDbType.Decimal));

				if (model.VatValue.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@VatValue", model.VatValue.Value, SqlDbType.Decimal));

				result = ControllerManager.ExecuteSP("TariffBookDelete", listParameters, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool ReadModelData(SqlDataReader reader, ref string msg)
		{
			try
			{
				TariffBookModel model = new TariffBookModel();

				model.LastUpdateDT = ControllerManager.Converter.ToDateTime(reader["LastUpdateDT"]);
				model.s1P1Duty = ControllerManager.Converter.ToDecimal(reader["s1P1Duty"]);
				model.s1P2ACode = ControllerManager.Converter.ToString(reader["s1P2ACode"]);
				model.s1P2ADuty = ControllerManager.Converter.ToDecimal(reader["s1P2ADuty"]);
				model.s1P2BDuty = ControllerManager.Converter.ToDecimal(reader["s1P2BDuty"]);
				model.s1P3ACode = ControllerManager.Converter.ToString(reader["s1P3ACode"]);
				model.s1P3ADuty = ControllerManager.Converter.ToDecimal(reader["s1P3ADuty"]);
				model.s1P3BCode = ControllerManager.Converter.ToString(reader["s1P3BCode"]);
				model.s1P3BDuty = ControllerManager.Converter.ToDecimal(reader["s1P3BDuty"]);
				model.s1P3CCode = ControllerManager.Converter.ToString(reader["s1P3CCode"]);
				model.s1P3CDuty = ControllerManager.Converter.ToDecimal(reader["s1P3CDuty"]);
				model.s1P3DCode = ControllerManager.Converter.ToString(reader["s1P3DCode"]);
				model.s1P3DDuty = ControllerManager.Converter.ToDecimal(reader["s1P3DDuty"]);
				model.s1P5ADuty = ControllerManager.Converter.ToDecimal(reader["s1P5ADuty"]);
				model.s1P5BDuty = ControllerManager.Converter.ToDecimal(reader["s1P5BDuty"]);
				model.s2P1Duty = ControllerManager.Converter.ToDecimal(reader["s2P1Duty"]);
				model.s2P1DutyCode = ControllerManager.Converter.ToString(reader["s2P1DutyCode"]);
				model.s2P2Duty = ControllerManager.Converter.ToDecimal(reader["s2P2Duty"]);
				model.s2P2DutyCode = ControllerManager.Converter.ToString(reader["s2P2DutyCode"]);
				model.s2P3Duty = ControllerManager.Converter.ToDecimal(reader["s2P3Duty"]);
				model.s2P3DutyCode = ControllerManager.Converter.ToString(reader["s2P3DutyCode"]);
				model.TariffCode = ControllerManager.Converter.ToString(reader["TariffCode"]);
				model.TariffStatusID = ControllerManager.Converter.ToByte(reader["TariffStatusID"]);
				model.TotalDue = ControllerManager.Converter.ToDecimal(reader["TotalDue"]);
				model.TotalDuties = ControllerManager.Converter.ToDecimal(reader["TotalDuties"]);
				model.VatValue = ControllerManager.Converter.ToDecimal(reader["VatValue"]);

				this.Add(model);

				return true;
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				return false;
			}
		}

		public void ClearModelData()
		{
			Clear();
		}

		#region - Methods : Dispose -

		private bool _disposed = false;

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					ClearModelData();
				}
			}
			_disposed = true;
		}

		#endregion
	}
}
