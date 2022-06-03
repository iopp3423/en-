package controls;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.regex.Pattern;

import models.MemberData;
import models.MemberDto;
import utility.Constants;

public class Controller {

	public MemberData data;
	public MemberDto dto;
	public List<MemberDto> members;
	public List<MemberDto> loginId;
	public List<MemberDto> searchId;
	
	public Controller() {
		data = new MemberData();
		dto = new MemberDto();
		members = new ArrayList<MemberDto>();
		loginId = new ArrayList<MemberDto>();
		searchId = new ArrayList<MemberDto>();
	}
	
	public boolean loginControl(String id, char[] pw) {
		
		members = data.returnMember(); //데베 유저 목록 리스트로 받기
		
		for (MemberDto member : members) {
			if(member.getId().equals(id) && Arrays.equals(pw, member.getPassword().toCharArray())) {
				loginId.add(new MemberDto(member.getName(), member.getId(),member.getPassword(),member.getBirth(),member.getEmail(),member.getCallNumber(),member.getAddress(),member.getZipCode()));
				return true; 
			}
			if(id.equals("")) 
				return true;
        }
		return false;
	}
	
	
	public boolean checkId(String id) {	
		members = data.returnMember(); //데베 유저 목록 리스트로 받기
		
		for (MemberDto member : members) {

			if(member.getId().equals(id)) {
				return false;// 중복아이디 있
			}
        }
		return true;// 중복아이디 없음
	}
	
	public String checkMember(String name, String id, String password, String passwordCheck, String birth, String email, String callNumber, String address, String zipCode) {// 회원가입 
		
		if(name.equals("") || id.equals("") || password.equals("") || passwordCheck.equals("") 
				|| birth.equals("") || email.equals("") || callNumber.equals("") || address.equals("") || address.equals(""))
					return "8";
		
		if(!(password.equals(passwordCheck))) return "1";
		if(!Pattern.matches(Constants.PWCHECK, id)) return "2";
		if(!Pattern.matches(Constants.PWCHECK, password)) return "3";
		if(!Pattern.matches(Constants.BIRTH, birth)) return "4";
		if(!Pattern.matches(Constants.EMAIL, email)) return "5";
		if(!Pattern.matches(Constants.CALLNUMBER, callNumber)) return "6";
		if(!Pattern.matches(Constants.NAMEKOREAN, name) && !Pattern.matches(Constants.NAMEENGLSIGH, name)) return "7";
				
		
		data.addMember(name, id, password, passwordCheck, birth, email, callNumber, address, zipCode);
		return "0";
	}
	
	
	public String reviseMember(String name, String password, String passwordCheck, String birth, String email, String callNumber, String address, String zipCode) { // 회원정보 수정 
		
		if(!Pattern.matches(Constants.NAMEKOREAN, name) && !Pattern.matches(Constants.NAMEENGLSIGH, name)) return "0";
		if(!(password.equals(passwordCheck))) return "1";
		if(!Pattern.matches(Constants.PWCHECK, password)) return "2";
		if(!Pattern.matches(Constants.BIRTH, birth)) return "3";
		if(!Pattern.matches(Constants.EMAIL, email)) return "4";
		if(!Pattern.matches(Constants.CALLNUMBER, callNumber)) return "5";
		if(name.equals("") || password.equals("") || passwordCheck.equals("") 
		|| birth.equals("") || email.equals("") || callNumber.equals("") || address.equals("") || address.equals(""))
					return "6";
				
		data.reviseMember(name, password, birth, email, callNumber, address, zipCode, loginId.get(0).getId());
		loginId.get(0).setName(name);
		loginId.get(0).setPassword(password);
		loginId.get(0).setBirth(birth);
		loginId.get(0).setEmail(email);
		loginId.get(0).setCallNumber(callNumber);
		loginId.get(0).setAddress(address);
		loginId.get(0).setZipCode(zipCode);
		return "7";
	}
	public void removeMember() {;
		data.removeMember(loginId.get(0).getId());
		
	}
	
	public boolean checkData(String storeddata, String email) {
		members = data.returnMember(); //데베 유저 목록 리스트로 받기
		
		for (MemberDto member : members) {

			if(member.getName().equals(storeddata) && member.getEmail().equals(email)
			|| member.getId().equals(storeddata) && member.getEmail().equals(email)) {
				searchId.add(new MemberDto(member.getName(), member.getId(),member.getPassword(),member.getBirth(),member.getEmail(),member.getCallNumber(),member.getAddress(),member.getZipCode()));
				return true; // 계정정보가 맞으면 
			}
        }
		return false; // 계정정보가 틀리면 
	}
	
	

}
