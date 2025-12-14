Feature: Busca de CEP e Rastreamento nos Correios

  Scenario: Validar CEP inexistente, CEP válido e rastreamento inválido
    Given que acesso o site dos Correios
    When realizo a busca pelo CEP "88034-900"
    Then devo ver a mensagem de CEP inexistente ou Preencha o campo Captcha
    
    When retorno para a tela inicial
    And realizo a busca pelo CEP "01013-001"
    Then devo ver a mensagem de CEP inexistente ou Preencha o campo Captcha

	When vai para a tela rastreamento
    And realizo a busca de rastreamento pelo codigo "SS987654321BR"
    Then devo ver a mensagem de CEP inexistente ou Preencha o campo Captcha