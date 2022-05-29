package models;

public class RouteLocation {
	private String home = System.getProperty("user.home");
	private String currentLocation= System.getProperty("user.home");
	private String errorMessage="";
	private String temporaryStorage="";
	
	public String getHome() {
		return home;
	}
	
	public void setCurrentLocation(String location) {
		this.currentLocation = location;
	}
	public String getCurrentLocation() {
		return currentLocation;
	}
	public void setErrorMessage(String errorMessage) {
		this.errorMessage= errorMessage; 
	}
	public String getErrorMessage() {
		return errorMessage;
	}
	public void setTemporaryStorage(String temporaryStorage) {
		this.temporaryStorage= temporaryStorage; 
	}
	public String getTemporaryStorage() {
		return temporaryStorage;
	}
}