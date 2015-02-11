-- -----------------------------------------------------------------------
--	Transition Adjustment (MCSF Pg 14) -- Used in Low Income Calculations
-- -----------------------------------------------------------------------
If not exists(SELECT * FROM TransitionAdjustments WHERE [ChildCount] = 1)
INSERT INTO TransitionAdjustments (ChildCount, Multiplier) VALUES (1, .50)

If not exists(SELECT * FROM TransitionAdjustments WHERE [ChildCount] = 2)
INSERT INTO TransitionAdjustments (ChildCount, Multiplier) VALUES (2, .55)

If not exists(SELECT * FROM TransitionAdjustments WHERE [ChildCount] = 3)
INSERT INTO TransitionAdjustments (ChildCount, Multiplier) VALUES (3, .60)

If not exists(SELECT * FROM TransitionAdjustments WHERE [ChildCount] = 4)
INSERT INTO TransitionAdjustments (ChildCount, Multiplier) VALUES (4, .65)

If not exists(SELECT * FROM TransitionAdjustments WHERE [ChildCount] = 5)
INSERT INTO TransitionAdjustments (ChildCount, Multiplier) VALUES (5, .70)

-- --------------------------------------------------
--	Additional Children (MCSF Pg 12)
-- --------------------------------------------------
SET IDENTITY_INSERT AdditionalChildrens ON

If not exists(SELECT * FROM AdditionalChildrens WHERE [ChildCount] = 0)
INSERT INTO AdditionalChildrens (ChildCount, Multiplier) VALUES (0, 1.00)

If not exists(SELECT * FROM AdditionalChildrens WHERE [ChildCount] = 1)
INSERT INTO AdditionalChildrens (ChildCount, Multiplier) VALUES (1, .85)

If not exists(SELECT * FROM AdditionalChildrens WHERE [ChildCount] = 2)
INSERT INTO AdditionalChildrens (ChildCount, Multiplier) VALUES (2, .77)

If not exists(SELECT * FROM AdditionalChildrens WHERE [ChildCount] = 3)
INSERT INTO AdditionalChildrens (ChildCount, Multiplier) VALUES (3, .72)

If not exists(SELECT * FROM AdditionalChildrens WHERE [ChildCount] = 4)
INSERT INTO AdditionalChildrens (ChildCount, Multiplier) VALUES (4, .69)

If not exists(SELECT * FROM AdditionalChildrens WHERE [ChildCount] = 5)
INSERT INTO AdditionalChildrens (ChildCount, Multiplier) VALUES (5, .66)

SET IDENTITY_INSERT AdditionalChildrens OFF
-- --------------------------------------------------
--	Ordinary Medical Expense Amount (MCSF Supplement Pg 1)
-- --------------------------------------------------
SET IDENTITY_INSERT OrdinaryMedExps ON

If not exists(SELECT * FROM OrdinaryMedExps WHERE [ChildCount] = 1)
INSERT INTO OrdinaryMedExps (ChildCount, AnnualAmount, MonthlyAmount) VALUES (1, 357, 29.75)

If not exists(SELECT * FROM OrdinaryMedExps WHERE [ChildCount] = 2)
INSERT INTO OrdinaryMedExps (ChildCount, AnnualAmount, MonthlyAmount) VALUES (2, 715, 59.58)

If not exists(SELECT * FROM OrdinaryMedExps WHERE [ChildCount] = 3)
INSERT INTO OrdinaryMedExps (ChildCount, AnnualAmount, MonthlyAmount) VALUES (3, 1072, 89.33)

If not exists(SELECT * FROM OrdinaryMedExps WHERE [ChildCount] = 4)
INSERT INTO OrdinaryMedExps (ChildCount, AnnualAmount, MonthlyAmount) VALUES (4, 1430, 119.17)

If not exists(SELECT * FROM OrdinaryMedExps WHERE [ChildCount] = 5)
INSERT INTO OrdinaryMedExps (ChildCount, AnnualAmount, MonthlyAmount) VALUES (5, 1787, 148.92)

SET IDENTITY_INSERT OrdinaryMedExps OFF
-- --------------------------------------------------
--	Low Income Threshold (MCSF Supplement Pg 1)
-- --------------------------------------------------

If not exists(SELECT * FROM LowIncomeThresholds WHERE [Amount] = 932)
INSERT INTO LowIncomeThresholds (Amount) VALUES (932)

-- --------------------------------------------------
--	General Care Support Tables (MCSF Supplement Pg 2-3)
-- --------------------------------------------------
SET IDENTITY_INSERT IncomeBrackets ON

If not exists(SELECT * FROM IncomeBrackets WHERE [IncomeBracketId] = 1)
INSERT INTO IncomeBrackets (IncomeBracketId, IncomeMin, IncomeMax) VALUES (1, 931, 1179)

If not exists(SELECT * FROM IncomeBrackets WHERE [IncomeBracketId] = 2)
INSERT INTO IncomeBrackets (IncomeBracketId, IncomeMin, IncomeMax) VALUES (2, 1179, 1894)

If not exists(SELECT * FROM IncomeBrackets WHERE [IncomeBracketId] = 3)
INSERT INTO IncomeBrackets (IncomeBracketId, IncomeMin, IncomeMax) VALUES (3, 1894, 2582)

If not exists(SELECT * FROM IncomeBrackets WHERE [IncomeBracketId] = 4)
INSERT INTO IncomeBrackets (IncomeBracketId, IncomeMin, IncomeMax) VALUES (4, 2582, 3314)

If not exists(SELECT * FROM IncomeBrackets WHERE [IncomeBracketId] = 5)
INSERT INTO IncomeBrackets (IncomeBracketId, IncomeMin, IncomeMax) VALUES (5, 3314, 4304)

If not exists(SELECT * FROM IncomeBrackets WHERE [IncomeBracketId] = 6)
INSERT INTO IncomeBrackets (IncomeBracketId, IncomeMin, IncomeMax) VALUES (6, 4304, 6111)

If not exists(SELECT * FROM IncomeBrackets WHERE [IncomeBracketId] = 7)
INSERT INTO IncomeBrackets (IncomeBracketId, IncomeMin, IncomeMax) VALUES (7, 6111, 7532)

If not exists(SELECT * FROM IncomeBrackets WHERE [IncomeBracketId] = 8)
INSERT INTO IncomeBrackets (IncomeBracketId, IncomeMin, IncomeMax) VALUES (8, 7532, 9468)

If not exists(SELECT * FROM IncomeBrackets WHERE [IncomeBracketId] = 9)
INSERT INTO IncomeBrackets (IncomeBracketId, IncomeMin, IncomeMax) VALUES (9, 9468, 9999999)

SET IDENTITY_INSERT IncomeBrackets OFF

-- --------------------------------------------------
--	General Care Support Tables (MCSF Supplement Pg 2-3)
-- --------------------------------------------------
If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 1 AND [IncomeBracket_IncomeBracketId] = 1)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (1, 1, 0, 0, .255)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 1 AND [IncomeBracket_IncomeBracketId] = 2)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (1, 2, .255, 300.65, .2417)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 1 AND [IncomeBracket_IncomeBracketId] = 3)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (1, 3, .250, 473.50, .1749)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 1 AND [IncomeBracket_IncomeBracketId] = 4)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (1, 4, .230, 593.86, .1666)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 1 AND [IncomeBracket_IncomeBracketId] = 5)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (1, 5, .216, 715.82, .1464)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 1 AND [IncomeBracket_IncomeBracketId] = 6)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (1, 6, .200, 860.80, .1391)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 1 AND [IncomeBracket_IncomeBracketId] = 7)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (1, 7, .182, 1112.20, .1237)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 1 AND [IncomeBracket_IncomeBracketId] = 8)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (1, 8, .171, 1287.97, .1123)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 1 AND [IncomeBracket_IncomeBracketId] = 9)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (1, 9, .159, 1505.41, .1000)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 2 AND [IncomeBracket_IncomeBracketId] = 1)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (2, 1, 0, 0, .394)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 2 AND [IncomeBracket_IncomeBracketId] = 2)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (2, 2, .394, 464.53, .3622)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 2 AND [IncomeBracket_IncomeBracketId] = 3)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (2, 3, .382, 723.51, .2619)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 2 AND [IncomeBracket_IncomeBracketId] = 4)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (2, 4, .350, 903.70, .2368)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 2 AND [IncomeBracket_IncomeBracketId] = 5)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (2, 5, .325, 1077.05, .2250)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 2 AND [IncomeBracket_IncomeBracketId] = 6)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (2, 6, .302, 1299.81, .2175)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 2 AND [IncomeBracket_IncomeBracketId] = 7)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (2, 7, .277, 1692.75, .2028)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 2 AND [IncomeBracket_IncomeBracketId] = 8)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (2, 8, .263, 1980.92, .1701)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 2 AND [IncomeBracket_IncomeBracketId] = 9)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (2, 9, .244, 2310.19, .1500)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 3 AND [IncomeBracket_IncomeBracketId] = 1)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (3, 1, 0, 0, .494)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 3 AND [IncomeBracket_IncomeBracketId] = 2)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (3, 2, .494, 582.43, .4728)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 3 AND [IncomeBracket_IncomeBracketId] = 3)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (3, 3, .486, 920.48, .3509)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 3 AND [IncomeBracket_IncomeBracketId] = 4)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (3, 4, .450, 1161.90, .3051)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 3 AND [IncomeBracket_IncomeBracketId] = 5)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (3, 5, .418, 1385.25, .2876)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 3 AND [IncomeBracket_IncomeBracketId] = 6)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (3, 6, .388, 1669.95, .2798)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 3 AND [IncomeBracket_IncomeBracketId] = 7)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (3, 7, .356, 2175.52, .2341)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 3 AND [IncomeBracket_IncomeBracketId] = 8)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (3, 8, .333, 2508.16, .1961)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 3 AND [IncomeBracket_IncomeBracketId] = 9)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (3, 9, .305, 2887.74, .1900)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 4 AND [IncomeBracket_IncomeBracketId] = 1)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (4, 1,  0, 0, .556)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 4 AND [IncomeBracket_IncomeBracketId] = 2)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (4, 2, .556, 655.52, .5269)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 4 AND [IncomeBracket_IncomeBracketId] = 3)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (4, 3, .545, 1032.23, .3986)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 4 AND [IncomeBracket_IncomeBracketId] = 4)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (4, 4, .506, 1306.49, .3430)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 4 AND [IncomeBracket_IncomeBracketId] = 5)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (4, 5, .470, 1557.58, .3309)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 4 AND [IncomeBracket_IncomeBracketId] = 6)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (4, 6, .438, 1885.15, .3196)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 4 AND [IncomeBracket_IncomeBracketId] = 7)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (4, 7, .403, 2462.73, .2493)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 4 AND [IncomeBracket_IncomeBracketId] = 8)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (4, 8, .374, 2816.97, .2322)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 4 AND [IncomeBracket_IncomeBracketId] = 9)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (4, 9, .345, 3266.46, .2200)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 5 AND [IncomeBracket_IncomeBracketId] = 1)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (5, 1, 0, 0, .608)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 5 AND [IncomeBracket_IncomeBracketId] = 2)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (5, 2, .608, 716.83, .5736)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 5 AND [IncomeBracket_IncomeBracketId] = 3)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (5, 3, .595, 1126.93, .4261)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 5 AND [IncomeBracket_IncomeBracketId] = 4)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (5, 4, .550, 1420.10, .3780)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 5 AND [IncomeBracket_IncomeBracketId] = 5)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (5, 5, .512, 1696.77, .3729)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 5 AND [IncomeBracket_IncomeBracketId] = 6)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (5, 6, .480, 2065.92, .3583)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 5 AND [IncomeBracket_IncomeBracketId] = 7)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (5, 7, .444, 2713.28, .2479)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 5 AND [IncomeBracket_IncomeBracketId] = 8)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (5, 8, .407, 3065.52, .2407)

If not exists(SELECT * FROM GeneralCareSupports WHERE [ChildCount] = 5 AND [IncomeBracket_IncomeBracketId] = 9)
INSERT INTO GeneralCareSupports (ChildCount, IncomeBracket_IncomeBracketId, BasePercent, BaseSupport, MarginalPercent) Values (5, 9, .373, 3531.56, .2300)

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------