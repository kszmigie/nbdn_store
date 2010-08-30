class Project
  def self.name
    @name = "nothinbutdotnetstore"
  end

  def self.startup_dir
    @startup_dir = "nothinbutdotnetstore.web.ui"
  end

  def self.specs_dir
    @specs_dir = "artifacts/specs"
  end

  def self.report_folder
    @report_folder = File.join(@specs_dir,'report')
  end

  def self.spec_assemblies
    @spec_assemblies = Dir.glob(File.join('artifacts',"nothin*specs.dll"))
  end

  def self.startup_config
    @startup_config = "web.config"
  end

  def self.startup_extension
    @startup_extension = ".dll"
  end

end
