package controls;

import java.util.ArrayList;
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
	
	public void loginControl(String id, String pw) {
		List<MemberDto> member = new ArrayList<MemberDto>();
		
		System.out.printf(id, pw);
		
		
		member = data.returnMember();
		
		for (MemberDto number : member) {
            System.out.println(number.getName());
        }
	}
}
