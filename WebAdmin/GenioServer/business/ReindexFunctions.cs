using ExecuteQueryCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using CSGenio.persistence;
using CSGenio.business;
using CSGenio.framework;
using Quidgest.Persistence.GenericQuery;
using Quidgest.Persistence;

namespace CSGenio.business
{
    public class ReindexFunctions
    {
        public PersistentSupport sp { get; set; }
        public User user { get; set; }
        public bool Zero { get; set; }

        public ReindexFunctions(PersistentSupport sp, User user, bool Zero = false) {
            this.sp = sp;
            this.user = user;
            this.Zero = Zero;
        }   

        public void DeleteInvalidRows(CancellationToken cToken) {
            List<int> zzstateToRemove = new List<int> { 1, 11 };
            DataMatrix dm;
            sp.openConnection();

            /* --- PJFCITY --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAcity.FldCodcity)
                .From(CSGenioAcity.AreaCITY)
                .Where(CriteriaSet.And().In(CSGenioAcity.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAcity model = new CSGenioAcity(user);
                model.ValCodcity = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PJFMEM --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAmem.FldCodmem)
                .From(CSGenioAmem.AreaMEM)
                .Where(CriteriaSet.And().In(CSGenioAmem.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAmem model = new CSGenioAmem(user);
                model.ValCodmem = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PJFPERSO --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAperso.FldCodperso)
                .From(CSGenioAperso.AreaPERSO)
                .Where(CriteriaSet.And().In(CSGenioAperso.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAperso model = new CSGenioAperso(user);
                model.ValCodperso = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- UserLogin --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioApsw.FldCodpsw)
                .From(CSGenioApsw.AreaPSW)
                .Where(CriteriaSet.And().In(CSGenioApsw.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioApsw model = new CSGenioApsw(user);
                model.ValCodpsw = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcess --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_apr.FldCodascpr)
                .From(CSGenioAs_apr.AreaS_APR)
                .Where(CriteriaSet.And().In(CSGenioAs_apr.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_apr model = new CSGenioAs_apr(user);
                model.ValCodascpr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- NotificationEmailSignature --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_nes.FldCodsigna)
                .From(CSGenioAs_nes.AreaS_NES)
                .Where(CriteriaSet.And().In(CSGenioAs_nes.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_nes model = new CSGenioAs_nes(user);
                model.ValCodsigna = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- NotificationMessage --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_nm.FldCodmesgs)
                .From(CSGenioAs_nm.AreaS_NM)
                .Where(CriteriaSet.And().In(CSGenioAs_nm.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_nm model = new CSGenioAs_nm(user);
                model.ValCodmesgs = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PJFAIRPT --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAairpt.FldCodairpt)
                .From(CSGenioAairpt.AreaAIRPT)
                .Where(CriteriaSet.And().In(CSGenioAairpt.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAairpt model = new CSGenioAairpt(user);
                model.ValCodairpt = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcessArgument --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_arg.FldCodargpr)
                .From(CSGenioAs_arg.AreaS_ARG)
                .Where(CriteriaSet.And().In(CSGenioAs_arg.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_arg model = new CSGenioAs_arg(user);
                model.ValCodargpr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcessAttachments --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_pax.FldCodpranx)
                .From(CSGenioAs_pax.AreaS_PAX)
                .Where(CriteriaSet.And().In(CSGenioAs_pax.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_pax model = new CSGenioAs_pax(user);
                model.ValCodpranx = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- UserAuthorization --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_ua.FldCodua)
                .From(CSGenioAs_ua.AreaS_UA)
                .Where(CriteriaSet.And().In(CSGenioAs_ua.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_ua model = new CSGenioAs_ua(user);
                model.ValCodua = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PJFAIRLN --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAairln.FldCodairln)
                .From(CSGenioAairln.AreaAIRLN)
                .Where(CriteriaSet.And().In(CSGenioAairln.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAairln model = new CSGenioAairln(user);
                model.ValCodairln = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PJFAPSW --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAapsw.FldCodhpsw)
                .From(CSGenioAapsw.AreaAPSW)
                .Where(CriteriaSet.And().In(CSGenioAapsw.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAapsw model = new CSGenioAapsw(user);
                model.ValCodhpsw = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PJFCREW --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAcrew.FldCodcrew)
                .From(CSGenioAcrew.AreaCREW)
                .Where(CriteriaSet.And().In(CSGenioAcrew.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAcrew model = new CSGenioAcrew(user);
                model.ValCodcrew = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PJFPILOT --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioApilot.FldCodpilot)
                .From(CSGenioApilot.AreaPILOT)
                .Where(CriteriaSet.And().In(CSGenioApilot.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioApilot model = new CSGenioApilot(user);
                model.ValCodpilot = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PJFPLANE --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAplane.FldCodplane)
                .From(CSGenioAplane.AreaPLANE)
                .Where(CriteriaSet.And().In(CSGenioAplane.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAplane model = new CSGenioAplane(user);
                model.ValCodplane = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PJFROUTE --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAroute.FldCodroute)
                .From(CSGenioAroute.AreaROUTE)
                .Where(CriteriaSet.And().In(CSGenioAroute.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAroute model = new CSGenioAroute(user);
                model.ValCodroute = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PJFFLIGH --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAfligh.FldCodfligh)
                .From(CSGenioAfligh.AreaFLIGH)
                .Where(CriteriaSet.And().In(CSGenioAfligh.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAfligh model = new CSGenioAfligh(user);
                model.ValCodfligh = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PJFMAINT --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAmaint.FldCodmaint)
                .From(CSGenioAmaint.AreaMAINT)
                .Where(CriteriaSet.And().In(CSGenioAmaint.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAmaint model = new CSGenioAmaint(user);
                model.ValCodmaint = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PJFMATE --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAmate.FldCodmate)
                .From(CSGenioAmate.AreaMATE)
                .Where(CriteriaSet.And().In(CSGenioAmate.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAmate model = new CSGenioAmate(user);
                model.ValCodmate = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PJFBOOKG --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAbookg.FldCodbookg)
                .From(CSGenioAbookg.AreaBOOKG)
                .Where(CriteriaSet.And().In(CSGenioAbookg.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAbookg model = new CSGenioAbookg(user);
                model.ValCodbookg = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                
            
            //Hard Coded Tabels
            //These can be directly removed

            /* --- PJFmem --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFmem")
                .Where(CriteriaSet.And().In("PJFmem", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFcfg --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFcfg")
                .Where(CriteriaSet.And().In("PJFcfg", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFlstusr --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFlstusr")
                .Where(CriteriaSet.And().In("PJFlstusr", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFlstcol --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFlstcol")
                .Where(CriteriaSet.And().In("PJFlstcol", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFlstren --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFlstren")
                .Where(CriteriaSet.And().In("PJFlstren", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFusrwid --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFusrwid")
                .Where(CriteriaSet.And().In("PJFusrwid", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFusrcfg --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFusrcfg")
                .Where(CriteriaSet.And().In("PJFusrcfg", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFusrset --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFusrset")
                .Where(CriteriaSet.And().In("PJFusrset", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFwkfact --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFwkfact")
                .Where(CriteriaSet.And().In("PJFwkfact", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFwkfcon --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFwkfcon")
                .Where(CriteriaSet.And().In("PJFwkfcon", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFwkflig --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFwkflig")
                .Where(CriteriaSet.And().In("PJFwkflig", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFwkflow --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFwkflow")
                .Where(CriteriaSet.And().In("PJFwkflow", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFnotifi --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFnotifi")
                .Where(CriteriaSet.And().In("PJFnotifi", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFprmfrm --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFprmfrm")
                .Where(CriteriaSet.And().In("PJFprmfrm", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFscrcrd --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFscrcrd")
                .Where(CriteriaSet.And().In("PJFscrcrd", "ZZSTATE", zzstateToRemove)));
                
            /* --- docums --- */
            sp.Execute(new DeleteQuery()
                .Delete("docums")
                .Where(CriteriaSet.And().In("docums", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFpostit --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFpostit")
                .Where(CriteriaSet.And().In("PJFpostit", "ZZSTATE", zzstateToRemove)));
                
            /* --- hashcd --- */
            sp.Execute(new DeleteQuery()
                .Delete("hashcd")
                .Where(CriteriaSet.And().In("hashcd", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFalerta --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFalerta")
                .Where(CriteriaSet.And().In("PJFalerta", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFaltent --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFaltent")
                .Where(CriteriaSet.And().In("PJFaltent", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFtalert --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFtalert")
                .Where(CriteriaSet.And().In("PJFtalert", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFdelega --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFdelega")
                .Where(CriteriaSet.And().In("PJFdelega", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFTABDINAMIC --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFTABDINAMIC")
                .Where(CriteriaSet.And().In("PJFTABDINAMIC", "ZZSTATE", zzstateToRemove)));
                
            /* --- UserAuthorization --- */
            sp.Execute(new DeleteQuery()
                .Delete("UserAuthorization")
                .Where(CriteriaSet.And().In("UserAuthorization", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFaltran --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFaltran")
                .Where(CriteriaSet.And().In("PJFaltran", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFworkflowtask --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFworkflowtask")
                .Where(CriteriaSet.And().In("PJFworkflowtask", "ZZSTATE", zzstateToRemove)));
                
            /* --- PJFworkflowprocess --- */
            sp.Execute(new DeleteQuery()
                .Delete("PJFworkflowprocess")
                .Where(CriteriaSet.And().In("PJFworkflowprocess", "ZZSTATE", zzstateToRemove)));
                

            sp.closeConnection();
        }




 
        // USE /[MANUAL RDX_STEP]/
    }
}