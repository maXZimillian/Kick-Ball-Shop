mergeInto(LibraryManager.library, {
	OnLoaded: function(){
		window.dispatchReactUnityEvent(
			"OnLoaded"
		);
	},
	OnStarted: function(){
		window.dispatchReactUnityEvent(
			"OnStarted"
		);
	},
	OnExit: function(value){
		window.dispatchReactUnityEvent(
			"OnExit",
			value
		);
	},
	OnPurchase: function(value1, value2){
		window.dispatchReactUnityEvent(
			"OnPurchase",
			value1,
			value2
		);
	}
});