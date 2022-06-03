package controls;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import models.MemberData;
import models.MemberDto;

public class controller {

	public MemberData data;
	public MemberDto dto;
	
	public controller() {
		data = new MemberData();
		dto = new MemberDto();
	}
	
	public boolean loginControl(String id, char[] pw) {
		List<MemberDto> member = new ArrayList<MemberDto>();
		
		member = data.returnMember();
		
		for (MemberDto number : member) {
			System.out.println(number.getPassword());
			System.out.println(pw);
			
			if(number.getId().equals(id) && Arrays.equals(pw, number.getPassword().toCharArray())) {
				return true;
			}
        }
		return false;
	}
}
