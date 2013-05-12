package 
{
	import flash.display.*;
	import flash.events.*;
	import flash.net.*;
	import flash.system.*;
	
	/**
	 * ...
	 * @author callee
	 */
	public class Main extends Sprite 
	{
		public const HOST:String = "http://app100645087.imgcache.qzoneapp.com/app100645087/xwygame/swf/GameLoader.swf?fv=beta201305110534";
		public const VARIABLES:String = "domain=qzone&amp;rootURL=http://app100645087.imgcache.qzoneapp.com/app100645087/xwygame&amp;serverURL=http://app100645087.qzone.qzoneapp.com/gateway.php&amp;socketURL=xwycsrv.app100645087.twsapp.com:80&amp;sessionId=3t932bvr57a6g3vq3gt3acjfs2&amp;newguy=0&amp;ver=beta201305110534&amp;unencrypted=0&amp;tgwhead=tgw_l7_forward%0D%0AHost%3A+xwycsrv.app100645087.twsapp.com%3A80%0D%0A%0D%0A&amp;activitys=firstpay,yellowbuy,bbs,attention,invite,cdkey,superhero&amp;newActivity=&amp;activityIcons=firstpay,superhero&amp;black=0&amp;debug=0&amp;mshopstart=1368244800&amp;mshopend=1368460740";
		private var _loader:Loader;
		public function Main():void 
		{
			this.addEventListener(Event.ADDED_TO_STAGE, onAdd);
		}
		
		private function onAdd(evt:Event):void
		{
			this.removeEventListener(Event.ADDED_TO_STAGE, onAdd);
			Security.allowDomain("*");			
			init();
		}
		
		private function init():void
		{
			var context:LoaderContext = new LoaderContext(true);
			var variables:URLVariables = new URLVariables();
			variables.decode(VARIABLES);
			_loader = new Loader();
			addChild(_loader);
			_loader.contentLoaderInfo.addEventListener(Event.COMPLETE, onComplete);
			var request:URLRequest = new URLRequest(HOST);
			request.data = variables;
			_loader.load(request);
		}
		
		private function onComplete(evt:Event):void
		{
			_loader.contentLoaderInfo.removeEventListener(Event.COMPLETE, onComplete);
			
		}
		
	}
	
}