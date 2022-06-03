package controls;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.regex.Pattern;

import models.MemberData;
import models.MemberDto;
import utility.Constants;

public class controller {

	public MemberData data;
	public MemberDto dto;
	public List<MemberDto> members;
	public List<MemberDto> loginId;
	
	public controller() {
		data = new MemberData();
		dto = new MemberDto();
		members = new ArrayList<MemberDto>();
		loginId = new ArrayList<MemberDto>();
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
	
	public String checkMember(String name, String id, String password, String passwordCheck, String birth, String email, String callNumber, String address, String zipCode) {
		
		if(name.equals("") || id.equals("") || password.equals("") || passwordCheck.equals("") 
				|| birth.equals("") || email.equals("") || callNumber.equals("") || address.equals("") || address.equals(""))
					return "7";
		
		if(!(password.equals(passwordCheck))) return "1";
		if(!Pattern.matches(Constants.PWCHECK, password)) return "2";
		if(!Pattern.matches(Constants.BIRTH, birth)) return "3";
		if(!Pattern.matches(Constants.EMAIL, email)) return "4";
		if(!Pattern.matches(Constants.CALLNUMBER, callNumber)) return "5";
		if(!Pattern.matches(Constants.NAMEKOREAN, name) && !Pattern.matches(Constants.NAMEENGLSIGH, name)) return "6";
				
		
		data.addMember(name, id, password, passwordCheck, birth, email, callNumber, address, zipCode);
		return "0";
	}
	
	public void removeMember() {
		System.out.println("ddd");
		data.removeMember(loginId.get(0).getId());
	}
	

}
