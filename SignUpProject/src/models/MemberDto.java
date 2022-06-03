package models;

public class MemberDto {

	
	private String name;
	private String id;
    private String password;
    private String birth;
    private String email;
    private String callNumber;
    private String address;
    private String zipCode;
    
    public MemberDto(String name,String id, String password, String birth, String email, String callNumber, String address, String zipCode)
    {
        this.name = name;
        this.id = id;
        this.password = password;
        this.birth = birth;
        this.email = email;
        this.callNumber = callNumber;
        this.address = address;
        this.zipCode = zipCode;
    }

    public MemberDto() {
    	
    }
    
    public String getName() {
    	return name;
    }
    public String getId() {
    	return id;
    }
    public String getPassword() {
    	return password;
    }
    public String getBirth() {
    	return birth;
    }
    public String getEmail() {
    	return email;
    }
    public String getCallNumber() {
    	return callNumber;
    }
    public String getAddress() {
    	return address;
    }
    public String getZipCode() {
    	return zipCode;
    }
    
    
    public void setName(String name) {
    	this.name = name;
    }
    public void setId(String id) {
    	this.id = id;
    }
    public void setPassword(String password) {
    	this.password = password;
    }
    public void setBirth(String birth) {
    	this.birth = birth;
    }
    public void setCallNumber(String email) {
    	this.email = email;
    }
    public void setEmail(String callNumber) {
    	this.callNumber = callNumber;
    }
    public void setAddress(String address) {
    	this.address = address;
    }
    public void setZipCode(String zipCode) {
    	this.zipCode = zipCode;
    }
}
