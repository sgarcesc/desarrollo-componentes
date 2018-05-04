package org.pl.eshop.tests;

import java.util.Arrays;
import java.util.Collection;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.Parameterized;
import org.junit.runners.Parameterized.Parameters;
import org.pl.eshop.dto.Categoria;

@RunWith(Parameterized.class)
public class TestModeloCategoria {
	private String n;
	private String d;
	
	@Parameters
	public static Collection<Object[]> data() {
		return Arrays.asList(new Object[][] {
			{ "Noticias", "Bla" }, { "", ""}, { "Deportes", "" } , { "", "Bla" }
		});
	}
	
	public TestModeloCategoria(String nom, String desc) {
		n=nom;
		d=desc;
	}
	
	@Test
	public void test() {
		Categoria cat = new Categoria();
		try{
			cat.setNombre(n);
			cat.setDescripcion(d);
		}
		catch(IllegalArgumentException e){
			System.out.println(e.getMessage());
			org.junit.Assert.fail(e.getMessage());
		}
	}
}