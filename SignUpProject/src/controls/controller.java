package controls;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import models.MemberData;
import models.MemberDto;

public class controller {

	public MemberData data;
	public MemberDto dto;
	public List<MemberDto> member;
	
	public controller() {
		data = new MemberData();
		dto = new MemberDto();
		member = new ArrayList<MemberDto>();
	}
	
	public boolean loginControl(String id, char[] pw) {
		
		member = data.returnMember(); //데베 유저 목록 리스트로 받기
		
		for (MemberDto number : member) {
			
			if(number.getId().equals(id) && Arrays.equals(pw, number.getPassword().toCharArray())) {
				return true; 
			}
			if(id.equals("")) 
				return true;
        }
		return false;
	}
	
	
	public boolean checkId(String id) {	
		member = data.returnMember(); //데베 유저 목록 리스트로 받기
		
		for (MemberDto number : member) {

			if(number.getId().equals(id)) {
				return false;// 중복아이디 있
			}
        }
		return true;// 중복아이디 없음
	}
	
	public String checkMember(String name, String id, String password, String passwordCheck, String birth, String email, String callNumber, String address, String zipCode) {
		if(!(password.equals(passwordCheck))) {
			return "1"; 
		}
		
		data.addMember(name, id, password, passwordCheck, birth, email, callNumber, address, zipCode);
		
		return "0";
	}
	
}
