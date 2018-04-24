package dominio;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public interface CategoriaDAO {
	public void agregar(Categoria c) throws Exception;
	
	public void modificar(Categoria c) throws Exception;
	
	public void eliminar(Categoria c) throws Exception;
	
	public List<Categoria> obtenerTodas() throws Exception;
	
	public Categoria obtenerPorId(Integer id) throws Exception;
}
