// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="">
//   Copyright � 2014 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BuildingBox.Web
{
	using System.Web.Optimization;
	 
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new StyleBundle("~/bundles/css").Include(
				"~/css/bootstrap.css",
				"~/css/bootstrap-theme.css",
				"~/css/bootstrap-additions.min.css",
				"~/css/perfect-scrollbar.css",
				"~/css/application.css",
				"~/css/loading-bar.min.css",
				"~/css/toastr.css",
				"~/css/dialogs.css",
				"~/css/jquery.fileupload.css",
				"~/css/jquery.fileupload-ui.css",
				"~/css/blueimp-gallery.min.css",
				"~/css/angular-ui-tree.min.css",
				"~/css/angular-motion.min.css",
				"~/css/select.css",
				"~/css/select2.css"
				));

			bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
				"~/scripts/jquery-2.1.0.min.js",
				"~/scripts/jquery.mousewheel.js",
				"~/scripts/jquery-ui-1.10.4.min.js",
				"~/scripts/angular.js",
				"~/scripts/angular-resource.min.js",
				"~/scripts/i18n/angular-locale_pt-br.js",
				"~/scripts/angular-mocks.js",
				"~/scripts/restful-ng-mock.js",
				"~/scripts/bootstrap.min.js",
				"~/scripts/ui-bootstrap-tpls-0.10.0.min.js",
				"~/scripts/angular-animate.min.js",
				"~/scripts/angular-ui-router.min.js",
				"~/scripts/angular-sanitize.min.js",
				"~/scripts/loading-bar.min.js",
				"~/scripts/spin.min.js",
				"~/scripts/angular-spinner.min.js",
				"~/scripts/toastr.min.js",
				"~/scripts/sortable.js",
				"~/scripts/keypress.js",
				"~/scripts/angular-strap.min.js",
				"~/scripts/angular-strap.tpl.min.js",
				"~/scripts/angular-draganddrop.js",
				"~/scripts/perfect-scrollbar.js",
				"~/scripts/angular-perfect-scrollbar.js",
				"~/scripts/select.min.js",
				"~/scripts/select2.min.js",
				"~/scripts/select2_locale_pt-BR.js",
				"~/scripts/angular_select2.js",
				"~/scripts/moment.js",
				"~/scripts/angular-ui-mask.min.js",
				"~/scripts/bindonce.min.js",
				"~/scripts/load-image.min.js",
				"~/scripts/canvas-to-blob.min.js",
				"~/scripts/jquery.blueimp-gallery.min.js",
				"~/scripts/jquery.iframe-transport.js",
				"~/scripts/jquery.fileupload.js",
				"~/scripts/jquery.fileupload-process.js",
				"~/scripts/jquery.fileupload-image.js",
				"~/scripts/jquery.fileupload-validate.js",
				"~/scripts/jquery.fileupload-angular.js",
				"~/scripts/angular-ui-tree.min.js",
				"~/scripts/ng-currency.js"
				));

			bundles.Add(new ScriptBundle("~/bundles/app").Include(
				"~/app/_shared/filters.js",
				"~/app/services.js",
				"~/app/_shared/directives.js",
				"~/app/_shared/directives.validator.js",
				"~/app/_shared/filtro/diretivaFiltro.js",
				"~/app/_shared/filtro/diretivaNgFiltro.js",
				"~/app/_shared/filtro/diretivaFiltroParametrizacao.js",
				"~/app/_shared/filtro/diretivaNgFiltroParametrizacao.js",
				"~/app/_shared/logo/diretivaNgLogo.js",
				"~/app/_shared/paginacao/diretivaNgPaginacao.js",
				"~/app/_shared/controllers.js",
				"~/app/_shared/HighlightService.js",
				"~/app/_shared/MenuController.js",
				"~/app/_shared/NgSelectsService.js",
				"~/app/app.js",

				"~/app/site/home/HomeController.js",
				"~/app/site/features/FeaturesController.js",
				"~/app/site/login/AuthInterceptorService.js",
				"~/app/site/login/AuthService.js",
				"~/app/site/login/LoginController.js",
				"~/app/site/customization/SiteCustomizationController.js",
				"~/app/site/videos/VideosController.js",
				"~/app/site/register/RegisterController.js",
				"~/app/site/simulation/SimulationController.js",
				"~/app/site/about/AboutController.js",

				"~/app/userPanel/userPanelController.js",

				"~/app/clientPanel/ClientPanelController.js",
				"~/app/clientPanel/ClientPanelContractsController.js",
				"~/app/clientPanel/ClientPanelMeetingsController.js",
				"~/app/clientPanel/ClientPanelCustomizationsController.js",
				"~/app/clientPanel/ClientPanelSetupController.js",
				"~/app/clientPanel/ClientPanelTicketsController.js",

				"~/app/ticket/TicketController.js",
				"~/app/customization/CustomizationController.js",
				"~/app/contract/ContractController.js",
				"~/app/meeting/MeetingController.js"

				));

			BundleTable.EnableOptimizations = false;
		}
	}
}
